using UnityEngine;
using UnityEngine.EventSystems;

public class PhysicsPointer : MonoBehaviour
{

    public float defaultLength = 4.0f;
    public GameObject dot;

    private LineRenderer lineRenderer = null;

    public GameObject[] animationController;

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
        dot.GetComponent<MeshRenderer>().material.color = Color.red;
        // default value or lengght


        // create raycast
        RaycastHit hit = CreateRaycast(defaultLength);

        // default length
        Vector3 endPosition = transform.position + (transform.forward * defaultLength);

        // or based on hit
        if (hit.collider)
        {
            endPosition = hit.point;
            if (hit.collider.tag == "victimHead" && animationController.Length !=0)
            {
                if (animationController[0].GetComponent<AnimationController>().headAnchorbool == true)
                {
                    dot.transform.localScale = new Vector3(.01f, .01f, .01f);
                    dot.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
                
            }
            if (hit.collider.tag == "victimChest" && animationController.Length != 0)
            {
                if (animationController[0].GetComponent<AnimationController>().chestAnchorBool == true)
                {
                    dot.transform.localScale = new Vector3(.01f, .01f, .01f);
                    dot.GetComponent<MeshRenderer>().material.color = Color.blue;
                }

            }
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

}
