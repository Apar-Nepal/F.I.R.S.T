using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

public class UIPointer : MonoBehaviour
{
    public float defaultLength = 4.0f;
    public GameObject dot;
    public VRInputModule inputModue;

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
        PointerEventData data = inputModue.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0? defaultLength : data.pointerCurrentRaycast.distance;

        // create raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // default length
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

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

    private RaycastHit CreateRaycast (float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
