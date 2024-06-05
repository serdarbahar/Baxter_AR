using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdjustText : MonoBehaviour
{

    // Start is called before the first frame update
    public Slider Slider;
    public TextMeshProUGUI textMeshPro;
    public ArticulationBody joint ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Slider.value > 0)
            textMeshPro.text = (Slider.value).ToString("0.000") + "°";
        else
            textMeshPro.text = (Slider.value).ToString("0.000") + "°";
        

    }
}
