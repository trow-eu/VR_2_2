using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    public GameObject selectionObject;
    public List<Material> otherObjects = new List<Material>();

    public Transform spawnPoint;
    public GameObject mergeObject;
    public GameObject currentObjects;
    public List<GameObject> mergeObjects = new List<GameObject>();

    private int currentObject= 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            {
                if(currentObject < otherObjects.Count-1)
                {
                    currentObject++;
                    selectionObject.GetComponent<MeshRenderer>().material = otherObjects[currentObject];
                    mergeObject = mergeObjects[currentObject];
                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            {
                if (currentObject > 0)
                {
                    currentObject--;
                    selectionObject.GetComponent<MeshRenderer>().material = otherObjects[currentObject];
                    mergeObject = mergeObjects[currentObject];
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
