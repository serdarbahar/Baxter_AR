using System;
using System.Threading;
using System.Collections;
using System.Linq;
using RosMessageTypes.Sensor;
using RosMessageTypes.Geometry;
using RosMessageTypes.Std;
using RosMessageTypes.BaxterCore;
using RosMessageTypes.Unity;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BaxterIKService : MonoBehaviour
{

    const int k_NumRobotJoints = 7;
    const float k_JointAssignmentWait = 0.1f;
    const float k_PoseAssignmentWait = 0.5f;

    readonly Quaternion m_PickOrientation = Quaternion.Euler(90, 90, 0);

    string[] leftLinkNames = {"base/torso/left_arm_mount/left_upper_shoulder", "/left_lower_shoulder", "/left_upper_elbow",
        "/left_lower_elbow", "/left_upper_forearm", "/left_lower_forearm", "/left_wrist"};

    string[] rightLinkNames = {"base/torso/right_arm_mount/right_upper_shoulder", "right_lower_shoulder", "right_upper_elbow",
        "right_lower_elbow", "right_upper_forearm", "right_lower_forearm", "right_wrist"};
   
    /*
    [SerializeField]
    public Dropdown selectedArm;
    */

    
    [SerializeField]
    public Slider slider_s0;

    [SerializeField]
    public Slider slider_s1;

    [SerializeField]
    public Slider slider_e0;

    [SerializeField] 
    public Slider slider_e1;

    [SerializeField] 
    public Slider slider_w0;

    [SerializeField]
    public Slider slider_w1;

    [SerializeField]
    public Slider slider_w2;

    [SerializeField]
    string m_ServiceName = "/ik_unity_helper_service";
    public string ServiceName { get => ServiceName; set => ServiceName = value; }

    [SerializeField]
    GameObject m_Baxter;
    public GameObject Baxter { get => m_Baxter; set => m_Baxter = value; }

    [SerializeField]
    GameObject m_Target;
    public GameObject Target { get => m_Target; set => m_Target = value;}

    // Articulation Bodies
    ArticulationBody[] m_leftJointArticulationBodies;
    ArticulationBody[] m_rightJointArticulationBodies;

    // ROS Connector
    ROSConnection m_Ros;


    void Start()
    {
         // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterRosService<IKHelperUnityRequest, IKHelperUnityResponse>(m_ServiceName);

        m_leftJointArticulationBodies = new ArticulationBody[k_NumRobotJoints];
        m_rightJointArticulationBodies = new ArticulationBody[k_NumRobotJoints];

        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += leftLinkNames[i];
            m_leftJointArticulationBodies[i] = m_Baxter.transform.Find(linkName).GetComponent<ArticulationBody>();
        }

        linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += "/";
            linkName += rightLinkNames[i];
            m_rightJointArticulationBodies[i] = m_Baxter.transform.Find(linkName).GetComponent<ArticulationBody>();
        }
    }

    public void requestIK() {

        //coordinates of the base link
        Vector3<FLU> diff = m_Baxter.transform.Find("base").position.To<FLU>();

        var endPoseMessage = new PoseMsg{
            position = m_Target.transform.position.To<FLU>() - diff,
            orientation = m_PickOrientation.To<FLU>()
        };

        IKHelperUnityRequest request = new IKHelperUnityRequest(endPoseMessage);

        m_Ros.SendServiceMessage<IKHelperUnityResponse>(m_ServiceName, request, executeResponse);
    }


    void executeResponse(IKHelperUnityResponse response) {


        // put all sliders in a slider list
        List<Slider> sliders = new List<Slider> {slider_s0, slider_s1, slider_e0, slider_e1, slider_w0, slider_w1, slider_w2};
       
        var i = 0;
        foreach (var jointState in response.joints) {
           
            if (!response.isValid[i]) {
                Debug.Log("Solution not found. Exiting.");
                break;
            }

            // traverse the slider list and assign the joint values
            for (int j = 0; j < sliders.Count; j++) {
                sliders[j].value = (float) jointState.position[j] * (float) (180 / Math.PI);
            }
            i++;
        }
    }
   


}
