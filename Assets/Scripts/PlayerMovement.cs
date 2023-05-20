using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float velMovimiento = 7f;
    public float sueloDrag;

    public float fueSalto;
    public float cdSalto;
    public float gravedad = 9.81f;
    //public float airMultiplier es para que el salto sea más largo si se salta en el aire
    public float airMultiplier;
    private bool puedeSaltar;

    [Header("Controles")]
    public KeyCode saltoKey = KeyCode.Space;


    [Header("EnSuelo")]
    public float distanciaSuelo;
    public LayerMask sueloMask;
    bool enSuelo;

    public Transform Orientación;

    float horizontalInput;
    float verticalInput;

    Vector3 dirMovimiento;

    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        //coge el componente y lo congela para que no rote sin querer
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        puedeSaltar = true;
    }

    // Update is called once per frame
    void Update()
    {
        //comprueba si está en el suelo con un raycast
        enSuelo = Physics.Raycast (transform.position, Vector3.down, distanciaSuelo + 0.2f, sueloMask);

        MiInput();

        ControlVelocidad();

        //si está en el suelo, le pone fricción para que no se deslice
        if (enSuelo) 
            rb.drag = sueloDrag; 
        else
            rb.drag = 0f;

    }

    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void MiInput()
    {
        //coge el input de los ejes
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //si se pulsa el botón de salto y está en el suelo, salta
        if (Input.GetKeyDown(saltoKey) && enSuelo && puedeSaltar)
        {
            Saltar();
            puedeSaltar = false;
            Invoke("resetSalto", cdSalto);
        }
    }

    private void MoverPlayer()
    {
        //normaliza el vector para que no se mueva más rápido en diagonal
        dirMovimiento = Orientación.forward * verticalInput + Orientación.right * horizontalInput;
        dirMovimiento.Normalize();

    //En suelo
        //mueve el rigidbody
        if(enSuelo)
            rb.AddForce(dirMovimiento * 5f * velMovimiento, ForceMode.Acceleration);
    //En el aire
        else if (!enSuelo){
        //añade fuerza al rigidbody en el aire
            rb.AddForce(dirMovimiento.normalized * velMovimiento * 10f *airMultiplier, ForceMode.Force);
        //añade gravedad al rigidbody
            rb.AddForce(Vector3.down * gravedad, ForceMode.Force);
        }
        
    }

    private void ControlVelocidad(){
        //limita la velocidad
        if (rb.velocity.magnitude > velMovimiento)
        {
            rb.velocity = rb.velocity.normalized * velMovimiento;
        }
    }

    private void Saltar()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //añade fuerza hacia arriba
        rb.AddForce(Vector3.up * fueSalto, ForceMode.Impulse);
    }

    private void resetSalto()
    {
        puedeSaltar = true;
    }
}
