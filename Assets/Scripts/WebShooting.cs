using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebShooting : MonoBehaviour
{
    public GameObject webBall;
    public GameObject SpiderWeb;
    public LineRenderer lr;
    public OVRInput.Controller controller = OVRInput.Controller.None;
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

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller) && Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            if (hit.collider.tag == "Fly")

            {
                Destroy(hit.collider.gameObject);
                lr.SetPosition(1, hit.point);
                lr.enabled = true;
            }
            else
            {
                Instantiate(SpiderWeb, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                lr.SetPosition(1, hit.point);
                lr.enabled = true;
            }
            
            
        }
        else
            lr.enabled = false;

    }
}
