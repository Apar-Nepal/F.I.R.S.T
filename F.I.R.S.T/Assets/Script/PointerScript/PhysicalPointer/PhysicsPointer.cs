using UnityEngine;
using UnityEngine.EventSystems;

public class PhysicsPointer : MonoBehaviour
{

    public float defaultLength = 4.0f;
    public GameObject dot;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // default value or lengght
        

        // create raycast
        RaycastHit hit = CreateRaycast(defaultLength);

        // default length
        Vector3 endPosition = transform.position + (transform.forward * defaultLength);

        // or based on hit
        if (hit.collider)
        {
            endPosition = hit.point;
        }


        // set position of the dot
        dot.transform.position = endPosition;

        // posiont of the line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }



    //public float defaultLength = 3.0f;
    //public GameObject Dot;

    //LineRenderer lineRenderer = null;

    //private void Awake()
    //{
    //    lineRenderer = this.GetComponent<LineRenderer>();
    //}

    //private void Update()
    //{

    //    UpdateLength();

    //}

    //private void UpdateLength()
    //{
    //    lineRenderer.SetPosition(0, this.transform.position);
    //    lineRenderer.SetPosition(1, CalculatedEnd());
    //}

    //Vector3 CalculatedEnd()
    //{
    //    RaycastHit hit = CreatedFowardRaycast();
    //    Vector3 endPosiotion = DefaultEnd(defaultLength);

    //    Dot.transform.position = endPosiotion;
    //    if (hit.collider)
    //    {
    //        endPosiotion = hit.point;
    //    }


    //    return endPosiotion;
    //}

    //RaycastHit CreatedFowardRaycast()
    //{
    //    RaycastHit hit;
    //    Ray ray = new Ray(transform.position, transform.forward);

    //    Physics.Raycast(ray, out hit, defaultLength);
    //    return hit;
    //}

    //private Vector3 DefaultEnd(float length)
    //{
    //    return transform.position + (transform.forward * length);
    //}
}
