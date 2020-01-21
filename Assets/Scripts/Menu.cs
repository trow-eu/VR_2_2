using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuThingy : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.None;
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Start, controller) == true)
        {
            this.gameObject.SetActive(true);
        }else
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
