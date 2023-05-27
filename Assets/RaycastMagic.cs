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
    

    void Awake() 
    {
        auraMagica = Instantiate(auraMagica, transform.position, Quaternion.identity);
        auraMagica.SetActive(false);
    }    
    
    void Start()
    {
       lineRenderer = GetComponent<LineRenderer>();
       proyectil = Instantiate(proyectil, transform.position, Quaternion.identity);
       proyectil.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Cursor.lockState = CursorLockMode.None; //Desbloquea el cursor
        Cursor.visible = true;                //Hace visible el cursor

        if(Input.GetMouseButton(1) && disparando == false) //el 1 es el boton derecho del mouse, el 0 es el izquierdo y el 2 es la rueda
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                hitPosition = hit.point;
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
        }

        if(Input.GetMouseButtonUp(1) && disparando == false)
        {
            disparando = true;
            proyectil.transform.position = transform.position;
            proyectil.SetActive(true);
        }

        proyectil.transform.position = Vector3.MoveTowards(proyectil.transform.position, hitPosition, 10f * Time.deltaTime);

        if(Vector3.Distance(proyectil.transform.position, hitPosition) < 0.1f)
        {
            proyectil.SetActive(false);
            auraMagica.SetActive(true);
            auraMagica.transform.position = hitPosition;
            proyectil.transform.position = transform.position;
            hitPosition = Vector3.zero;
        }
    
        if(auraMagica.activeSelf)
        {
            duracionAura -= Time.deltaTime;
            if(duracionAura <= 0)
            {
                auraMagica.SetActive(false);
                duracionAura = 2f;
                disparando = false;
            }
            
            auraMagica.GetComponent<Proyectil>().collider.enabled = true;

        }

    }



}
