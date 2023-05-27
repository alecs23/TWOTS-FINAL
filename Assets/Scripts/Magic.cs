using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Assign the player transform
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - playerTransform.position;

            // Set the positions of the line renderer
            lineRenderer.SetPosition(0, playerTransform.position);
            lineRenderer.SetPosition(1, playerTransform.position + direction);
        }
    }
}
