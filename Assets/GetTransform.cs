using UnityEngine;
using UnityEngine.UI;

public class GetTransform : MonoBehaviour
{
    public Transform leftController;
    public ArticulationBody baseLink;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 rot= new Vector3(0, leftController.transform.rotation.eulerAngles.y - 139, 0);
        baseLink.TeleportRoot(leftController.transform.position + (-0.01206f * baseLink.transform.forward) + ( -0.0946f * baseLink.transform.right) - (0.3f * transform.up),Quaternion.Euler(rot));

    }
    
    
}
