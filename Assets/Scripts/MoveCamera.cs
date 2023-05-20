using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
public Transform cameraPosition;
    
    // Esto hace que la camara siga al jugador mediante el empty cameraPosition
    private void Update()
    {
        transform.position= cameraPosition.position;
    }
}
