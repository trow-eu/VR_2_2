using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuThingy : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
            this.gameObject.SetActive(true);
            Debug.Log("oit");
        }
        else if (OVRInput.GetUp(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
            this.gameObject.SetActive(false);
        }

    }
}
