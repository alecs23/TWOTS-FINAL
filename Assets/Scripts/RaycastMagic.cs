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
    public GameObject proyectilAmarillo;
    public GameObject auraMagica;
    public GameObject auraMagicaAmarilla;
    public GameObject spherePrefab;
    public GameObject spherePrefabAmarilla;


    Vector3 hitPosition;

    public float duracionAura = 2f;
    public float duracionAuraAmarilla = 2f;
    bool disparando = false;
    public float radioEsfera;

    

    void Awake() 
    {
        auraMagica = Instantiate(auraMagica, transform.position, Quaternion.identity); //Instancia el prefab de la magia
        auraMagica.SetActive(false); //Desactiva el prefab de la magia
        spherePrefab = Instantiate(spherePrefab, transform.position, Quaternion.identity); //Instancia el collider del proyectil
        spherePrefab.SetActive(false); //Desactiva el collider del proyectil

        auraMagicaAmarilla = Instantiate(auraMagicaAmarilla, transform.position, Quaternion.identity); //Instancia el prefab de la magia
        auraMagicaAmarilla.SetActive(false); //Desactiva el prefab de la magia
        spherePrefabAmarilla = Instantiate(spherePrefabAmarilla, transform.position, Quaternion.identity); //Instancia el collider del proyectil
        spherePrefabAmarilla.SetActive(false); //Desactiva el collider del proyectil
    }    
    
    void Start()
    {
       //lineRenderer = GetComponent<LineRenderer>();
       proyectil = Instantiate(proyectil, transform.position, Quaternion.identity); //Instancia el prefab del proyectil
       proyectil.SetActive(false);  //Desactiva el prefab del proyectil

       proyectilAmarillo = Instantiate(proyectilAmarillo, transform.position, Quaternion.identity); //Instancia el prefab del proyectil
       proyectilAmarillo.SetActive(false);  //Desactiva el prefab del proyectil
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
        proyectilAmarillo.transform.position = Vector3.MoveTowards(proyectilAmarillo.transform.position, hitPosition, 10f * Time.deltaTime); //mueve el proyectil hacia la posicion del rayo desde la mano

        if(Vector3.Distance(proyectil.transform.position, hitPosition) < 0.1f) //si el proyectil llega a la posicion del rayo
        {
            proyectil.SetActive(false); //desactiva el prefab del proyectil
            auraMagica.SetActive(true); //activa el prefab de la magia
            auraMagica.transform.position = hitPosition; //coloca el prefab de la magia en la posicion del rayo
            proyectil.transform.position = transform.position; //coloca el proyectil en la posicion del jugador
            //hitPosition = Vector3.zero;
        }
    
        if(Vector3.Distance(proyectilAmarillo.transform.position, hitPosition) < 0.1f) //si el proyectil llega a la posicion del rayo
        {
            proyectilAmarillo.SetActive(false); //desactiva el prefab del proyectil
            auraMagicaAmarilla.SetActive(true); //activa el prefab de la magia
            auraMagicaAmarilla.transform.position = hitPosition; //coloca el prefab de la magia en la posicion del rayo
            proyectilAmarillo.transform.position = transform.position; //coloca el proyectil en la posicion del jugador
            //hitPosition = Vector3.zero;
        }

        if(auraMagica.activeSelf)
        {
            //TODO
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
        if(auraMagicaAmarilla.activeSelf)
        {
            //TODO AMARILLO
            duracionAuraAmarilla -= Time.deltaTime; //cuenta el tiempo que la magia esta activa
            proyectilAmarillo.transform.position = new Vector3 (-1000, -1000, -1000); //la mandamos a tomar por culo
            spherePrefabAmarilla.SetActive(true); //activamos el collider del proyectil
            spherePrefabAmarilla.transform.position = auraMagicaAmarilla.transform.position; //colocamos el collider del proyectil en la posicion de la magia

            if(duracionAuraAmarilla <= 0) 
            {
                spherePrefabAmarilla.transform.position = new Vector3 (-1000, -1000, -1000);
                auraMagicaAmarilla.SetActive(false); 
                duracionAuraAmarilla = 2f;
                disparando = false;
            }
        }


        //RAYO botón izquierdo (mandar bulbos) // cuando levanto el dedo del click
        if(Input.GetMouseButtonUp(0) && disparando == false)
        {

            ray = camera.ScreenPointToRay(Input.mousePosition); 
            if(Physics.Raycast(ray, out hit))
            {
                hitPosition = hit.point;
                //Debug.DrawLine(transform.position, hit.point, Color.red);
            }
            disparando = true; //activa la bool de disparo
            proyectilAmarillo.transform.position = transform.position; //coloca el proyectil en la posicion del jugador
            proyectilAmarillo.SetActive(true); //activa el prefab del proyectil
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