using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWebBall : MonoBehaviour
{

    public GameObject SpiderWeb;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
