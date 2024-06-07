using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrateSlider : MonoBehaviour
{

    [SerializeField]
    public Slider slider;
    
    [SerializeField]
    public ArticulationBody joint;
    // Start is called before the first frame update
    void Start()
    {
        // Calibrate the slider to the joint's limits
        ArticulationDrive currentDrive = joint.xDrive;
        float upperLimit = joint.xDrive.upperLimit; //positive
        float lowerLimit = joint.xDrive.lowerLimit; //negative
        slider.minValue = lowerLimit;
        slider.maxValue = upperLimit;
        slider.value = 0;
    }

}
