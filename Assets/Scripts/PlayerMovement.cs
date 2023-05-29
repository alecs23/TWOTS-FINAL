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
    public float airMultiplier;
    private bool puedeSaltar;
    public Animator AnimatorPastor;

    [Header("Controles")]
    public KeyCode saltoKey = KeyCode.Space;
    public KeyCode interactuarKey = KeyCode.E;

    [Header("EnSuelo")]
    public float distanciaSuelo;
    public LayerMask sueloMask;


    public Transform Orientación;

    float horizontalInput;
    float verticalInput;

    private bool Anda;
    private bool Interactua;
    bool enSuelo;
    bool Saltando;
    bool Cae;
    bool ActivaIdle;

    Vector3 dirMovimiento;

    Rigidbody rb;

    private Animator animator;

    void Start()
    {//inicializa el rigidbody y congela la rotación
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        puedeSaltar = true;

        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {//raycast para detectar el suelo
        enSuelo = Physics.Raycast(transform.position, Vector3.down, distanciaSuelo + 0.2f, sueloMask); 
        
        if (enSuelo && Input.GetKeyDown(interactuarKey))
        {
            animator.SetBool("Interactua" , true);
        }

        MiInput();

        ControlVelocidad();

        if (enSuelo)
        {
            rb.drag = sueloDrag;
            Cae = false;
        }
        else
        {
            rb.drag = 0f;
            Cae = true;
        }

            // AQUI ESTA EL MATATA, SI INTERACTUO NO PUEDO VOLVER AL IDLE.
        if (Input.GetKeyDown(interactuarKey))
        {
            animator.SetBool("Interactua" , true);
            animator.SetBool("ActivaIdle" , false);
            
        }else{
            animator.SetBool("Interactua" , false);
            animator.SetBool("ActivaIdle" , true);
        }

        Anda = enSuelo && (horizontalInput != 0 || verticalInput != 0);
        Interactua = Input.GetKeyDown(interactuarKey)  && !Saltando;
        Saltando = !enSuelo && rb.velocity.y > 0.1f;
        

        animator.SetBool("Anda", Anda);
        animator.SetBool("Interactua", Interactua);
        animator.SetBool("Saltando", Saltando);
        animator.SetBool("Cae", Cae);
        animator.SetBool("EnSuelo", enSuelo);
        animator.SetBool("ActivaIdle", ActivaIdle);
    }


    private void FixedUpdate()
    {
        MoverPlayer();
    }

    private void MiInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(saltoKey) && enSuelo && puedeSaltar)
        {
            Saltar();
            puedeSaltar = false;
            Invoke("resetSalto", cdSalto);
        }
    }

    private void MoverPlayer()
    {
        dirMovimiento = Orientación.forward * verticalInput + Orientación.right * horizontalInput;
        dirMovimiento.Normalize();
        //AQUI TAMBIEN POSIBLE MATATA, ACELERACION EN EL AIRE 
        if (enSuelo)
        {
            rb.AddForce(dirMovimiento * 5f * velMovimiento, ForceMode.Acceleration);
        }
        else if (!enSuelo)
        {
            rb.AddForce(dirMovimiento.normalized * velMovimiento * 10f , ForceMode.Force);
            rb.AddForce(Vector3.down * gravedad, ForceMode.Acceleration);
            
        }
    }

    private void ControlVelocidad()
    {
        if (rb.velocity.magnitude > velMovimiento)
        {
            rb.velocity = rb.velocity.normalized * velMovimiento;
        }//limita la velocidad máxima en el aire teniendo en cuenta la gravedad
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (airMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Saltar()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * fueSalto, ForceMode.Impulse);
    }

    private void resetSalto()
    {
        puedeSaltar = true;
    }
}
