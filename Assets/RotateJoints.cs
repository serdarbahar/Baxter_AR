using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateJoints : MonoBehaviour

{
    //public float speed ;
    public GameObject arm ;
    public Dropdown selectedArm ;
    public ArticulationBody joint ;
    public Slider slider ;
    
    // Start is called before the first frame update
    void Start()

    {
        joint = this.GetComponent<ArticulationBody>();
        ArticulationDrive currentDrive = joint.xDrive;
        currentDrive.stiffness = 10000f;
        currentDrive.damping = 100f;
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
        

        if (arm_value == selectedArm.value) {
            ArticulationDrive currentDrive = joint.xDrive;
            if (slider.value > 0) {
                currentDrive.target = slider.value * (joint.xDrive.upperLimit);
            }
            else {
                currentDrive.target = slider.value * (joint.xDrive.lowerLimit);
            }
            
            joint.xDrive = currentDrive;
        }
        
    }
}