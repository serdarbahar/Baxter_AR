using System;
using RosMessageTypes.Geometry;
using RosMessageTypes.BaxterCore;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
// using Unity.Robotics.UrdfImporter;
using UnityEngine;

public class BaxterEndpointStatePublisher : MonoBehaviour
{

    // Variables required for ROS communication
    [SerializeField]
    string m_TopicName = "/baxter_end_points";

    [SerializeField]
    GameObject m_Baxter;

    // ROS Connector
    ROSConnection m_Ros;

    void Start()
    {
        // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterPublisher<EndpointStatesMsg>(m_TopicName);
    }


    public void Publish()
    {
        var endpointStatesMessage = new EndpointStatesMsg();

        endpointStatesMessage.names = new string[] { "left", "right" };
        endpointStatesMessage.states = new EndpointStateMsg[2];

        //left
        endpointStatesMessage.states[0] = new EndpointStateMsg();
        Transform leftHand = m_Baxter.transform.Find("base/torso/left_arm_mount/left_upper_shoulder/left_lower_shoulder/left_upper_elbow/left_lower_elbow/left_upper_forearm/left_lower_forearm/left_wrist/left_hand");
        endpointStatesMessage.states[0].pose = new PoseMsg{
            position = leftHand.position.To<FLU>(),
            orientation = Quaternion.Euler(leftHand.position.x, leftHand.position.y, leftHand.position.z).To<FLU>()
        };


        //right
        endpointStatesMessage.states[1] = new EndpointStateMsg();
        Transform rightHand = m_Baxter.transform.Find("base/torso/right_arm_mount/right_upper_shoulder/right_lower_shoulder/right_upper_elbow/right_lower_elbow/right_upper_forearm/right_lower_forearm/right_wrist/right_hand");
        endpointStatesMessage.states[1].pose = new PoseMsg{
            position = rightHand.position.To<FLU>(),
            orientation = Quaternion.Euler(rightHand.position.x, rightHand.position.y, rightHand.position.z).To<FLU>()
        };

        // Finally send the message to server_endpoint.py running in ROS
        m_Ros.Publish(m_TopicName, endpointStatesMessage);
    }
}