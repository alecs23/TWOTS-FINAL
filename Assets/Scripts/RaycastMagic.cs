using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMagic : MonoBehaviour
{
    [SerializeField] private Transform posicioDisparo;
    private float rangoDisparo = 100f, duracionDisparo = 0.05f;
    private LineRenderer lineRenderer;
    public Camera camera;
    RaycastHit hit;
    Ray ray;
    public GameObject proyectil;
    public GameObject auraMagica;

    Vector3 hitPosition;

    public float duracionAura = 2f;
    bool disparando = false;
    public float radioEsfera;

    public GameObject spherePrefab;
    

    void Awake() 
    {
        auraMagica = Instantiate(auraMagica, transform.position, Quaternion.identity); //Instancia el prefab de la magia
        auraMagica.SetActive(false); //Desactiva el prefab de la magia
        spherePrefab = Instantiate(spherePrefab, transform.position, Quaternion.identity); //Instancia el collider del proyectil
        spherePrefab.SetActive(false); //Desactiva el collider del proyectil
    }    
    
    void Start()
    {
       //lineRenderer = GetComponent<LineRenderer>();
       proyectil = Instantiate(proyectil, transform.position, Quaternion.identity); //Instancia el prefab del proyectil
       proyectil.SetActive(false);  //Desactiva el prefab del proyectil
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.lockState = CursorLockMode.None; //Desbloquea el cursor
        Cursor.visible = true;                //Hace visible el cursor

        if(Input.GetMouseButtonDown(1) && disparando == false) //el 1 es el boton derecho del mouse, el 0 es el izquierdo y el 2 es la rueda
        {
            ray = camera.ScreenPointToRay(Input.mousePosition); //crea un rayo desde la camara hasta la posicion del mouse
            if(Physics.Raycast(ray, out hit))
            {
                hitPosition = hit.point; //guarda la posicion del rayo en una variable
                Debug.DrawLine(transform.position, hit.point, Color.red); //dibuja una linea roja desde la posicion del jugador hasta la posicion del rayo
            }
        }

        if(Input.GetMouseButtonUp(1) && disparando == false)
        {
            disparando = true; //activa la bool de disparo
            proyectil.transform.position = transform.position; //coloca el proyectil en la posicion del jugador
            proyectil.SetActive(true); //activa el prefab del proyectil
        }

        proyectil.transform.position = Vector3.MoveTowards(proyectil.transform.position, hitPosition, 10f * Time.deltaTime); //mueve el proyectil hacia la posicion del rayo desde la mano

        if(Vector3.Distance(proyectil.transform.position, hitPosition) < 0.1f) //si el proyectil llega a la posicion del rayo
        {
            proyectil.SetActive(false); //desactiva el prefab del proyectil
            auraMagica.SetActive(true); //activa el prefab de la magia
            auraMagica.transform.position = hitPosition; //coloca el prefab de la magia en la posicion del rayo
            proyectil.transform.position = transform.position; //coloca el proyectil en la posicion del jugador
            //hitPosition = Vector3.zero;
        }
    
        if(auraMagica.activeSelf)
        {
            duracionAura -= Time.deltaTime; //cuenta el tiempo que la magia esta activa
            proyectil.transform.position = new Vector3 (-1000, -1000, -1000); //la mandamos a tomar por culo
            spherePrefab.SetActive(true); //activamos el collider del proyectil
            spherePrefab.transform.position = auraMagica.transform.position; //colocamos el collider del proyectil en la posicion de la magia

            if(duracionAura <= 0) 
            {
                spherePrefab.transform.position = new Vector3 (-1000, -1000, -1000);
                auraMagica.SetActive(false); 
                duracionAura = 2f;
                disparando = false;
            }

        }

    }

void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(spherePrefab.transform.position, radioEsfera);
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(transform.position, hitPosition);
}
}