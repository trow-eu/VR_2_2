using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Climber climber = null;
    public OVRInput.Controller controller = OVRInput.Controller.None;

    public Vector3 Delta { private set; get; } = Vector3.zero;
    private Vector3 lastposition = Vector3.zero; 

    private GameObject currentPoint = null;
    private List<GameObject> contactPoints = new List<GameObject>();
    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        lastposition = transform.position;
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            GrabPoint();

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
            ReleasePoint(); 
    }

    private void FixedUpdate()
    {
        lastposition = transform.position;
    }

    private void LateUpdate()
    {
        Delta = lastposition - transform.position;
    }

    private void GrabPoint()
    {
        currentPoint = Utility.GetNearest(transform.position, contactPoints);

        if(currentPoint)
        {
            climber.SetHand(this);
            meshRenderer.enabled = false;
        }

    }

    public void ReleasePoint()
    {
        if (currentPoint)
        {
            climber.Clearhand();
            meshRenderer.enabled = true;
        }

        currentPoint = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddPoint(other.gameObject);
    }

    private void AddPoint(GameObject newObject)
    {
        if (newObject.CompareTag("Climbable"))
            contactPoints.Add(newObject);
    }

    private void OnTriggerExit(Collider other)
    {
        RemovePoint(other.gameObject);
    }

    private void RemovePoint(GameObject newObject)
    {
        if (newObject.CompareTag("Climbable"))
            contactPoints.Remove(newObject);
    }
}
