using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuting : MonoBehaviour
{
    public GameObject DestroyedVersion;
    public OVRInput.Controller controller = OVRInput.Controller.None;
    public Animator CutAnim;
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Cut" && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("Cut");
            Instantiate(DestroyedVersion, transform.position, transform.rotation);
            this.gameObject.SetActive(false);
            CutAnim.SetBool("Cut", true);
        }
        else
            CutAnim.SetBool("Cut", false);
    }
}
