using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HechizoDespertar : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    private float laserRange = 100f, laserDuration = 0.05f;
    private LineRenderer lineRenderer;
    public Camera camera;
    RaycastHit hit;
    

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Ray ray = new Ray(rayOrigin, camera.transform.forward);

            lineRenderer.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);
            }
            else
            {
                lineRenderer.SetPosition(1, shootPosition.position + (shootPosition.forward * laserRange));
            }
            StartCoroutine(RenderLine());
        }

        IEnumerator RenderLine()
        {
            lineRenderer.enabled = true;
            yield return new WaitForSeconds(laserDuration);
            lineRenderer.enabled = false;
        }

        /* float maxDistance = 5f;
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.direction * maxDistance, Color.red);   

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            print(hit.transform.name);  
        }*/

    }
}