using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //bloquea el cursor en el centro de la pantalla
        Cursor.visible = false; //hace que el cursor no sea visible

    }

    // Update is called once per frame
    void Update()
    {
        //coge el input del ratón
        float mouseX= Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float mouseY= Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //para que no pueda rotar más de 90 grados hacia arriba o hacia abajo

        //rota la cámara en función del input del ratón
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        
    }
}
