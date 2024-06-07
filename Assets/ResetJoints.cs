using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetJoints : MonoBehaviour
{

    [SerializeField]
    public Slider Slider_s0;

    [SerializeField]
    public Slider Slider_s1;

    [SerializeField]
    public Slider Slider_e0;

    [SerializeField]
    public Slider Slider_e1;

    [SerializeField]
    public Slider Slider_w0;

    [SerializeField]
    public Slider Slider_w1;

    [SerializeField]
    public Slider Slider_w2;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {

    }

    public void JointReset()
    {
        
        
        List<Slider> sliders = new List<Slider> {Slider_s0, Slider_s1, Slider_e0, Slider_e1, Slider_w0, Slider_w1, Slider_w2};

        // Reset sliders to 0
        foreach (Slider slider in sliders) {
            slider.value = 0;
        }
        
        
    
    }
}

