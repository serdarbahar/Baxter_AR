using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateJoints : MonoBehaviour

{
    //public float speed ;
    public GameObject arm ;
    public Toggle selectedArm ;
    public ArticulationBody joint ;
    public Slider slider ;
    
    // Start is called before the first frame update
    void Start()

    {
        joint = this.GetComponent<ArticulationBody>();
        ArticulationDrive currentDrive = joint.xDrive;
        currentDrive.stiffness = 10000f;
        currentDrive.damping = 2000f;
        currentDrive.forceLimit = 1000f;
        joint.xDrive = currentDrive;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        int arm_value;
        if (arm.name == "Left")
            arm_value = 0;
        else
            arm_value = 1;
        
        //selectedArm.isOn -> right
        if ( (selectedArm.isOn && arm_value == 1) || (!selectedArm.isOn && arm_value == 0) ) { 
            ArticulationDrive currentDrive = joint.xDrive;

            currentDrive.target = slider.value;
            
            joint.xDrive = currentDrive;
        }
        
    }
}