using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebShooting : MonoBehaviour
{
    public GameObject webBall;
    public GameObject SpiderWeb;
    public LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
            Debug.DrawRay(transform.position, fwd * 10, Color.green);

            if(Input.GetButtonDown("Oculus_CrossPlatform_Button4")&& Physics.Raycast(transform.position, fwd, out hit, 10))
            {
                Instantiate(SpiderWeb, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            lr.SetPosition(1, hit.point);
            lr.enabled = true;
            }

    }
}
