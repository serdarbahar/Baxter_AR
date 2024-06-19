using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{


    public Button button;

    
    public void Move() {
        // move the button
        Vector3 currRectTransform = button.GetComponent<RectTransform>().anchoredPosition;
        currRectTransform.x -= 10;
        button.GetComponent<RectTransform>().anchoredPosition = currRectTransform;
    }
}
