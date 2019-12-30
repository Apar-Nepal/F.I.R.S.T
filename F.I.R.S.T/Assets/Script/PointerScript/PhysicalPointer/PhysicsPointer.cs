using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PhysicsPointer : MonoBehaviour
{
    public float defaultLength = 3.0f;
    public GameObject Dot;

    LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
        UpdateLength();
        
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, CalculatedEnd());
    }

    Vector3 CalculatedEnd()
    {
        RaycastHit hit = CreatedFowardRaycast();
        Vector3 endPosiotion = DefaultEnd(defaultLength);

        Dot.transform.position = endPosiotion;
        if (hit.collider)
        {
            endPosiotion = hit.point;
        }


        return endPosiotion;
    }

    RaycastHit CreatedFowardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }
}
