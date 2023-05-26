using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptLibro : MonoBehaviour
{
    public GameObject CanvasLibro;
    public GameObject Pagina1;
    public GameObject Pagina2;
    public GameObject Pagina3;
    bool LibroAbierto = false;

    void Start()
    {
        CanvasLibro.SetActive(true);
        Pagina1.SetActive(false);
        Pagina2.SetActive(false);
        Pagina3.SetActive(false);
    }

    void Update()
    {
        
         if(Input.GetKeyDown(KeyCode.I))
        {
            LibroAbierto = !LibroAbierto;
        }

        if(LibroAbierto == true)
        {
            CanvasLibro.SetActive(true);
            Pagina1.SetActive(true);
        }

        else
        {
            CanvasLibro.SetActive(false);
            Pagina1.SetActive(false);
        }

        if(Pagina1.activeSelf == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Pagina1.SetActive(false);
            Pagina2.SetActive(true);
        }

       /* if(CanvasLibro == true && Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasLibro.SetActive(false);
        }

        if(Pagina1 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Pagina1.SetActive(false);
            Pagina2.SetActive(true);
        }

        if(Pagina2 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Pagina2.SetActive(false);
            Pagina3.SetActive(true);
        }

        if(Pagina2 == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Pagina2.SetActive(false);
            Pagina1.SetActive(true);
        }

        if(Pagina3 == true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Pagina3.SetActive(false);
            Pagina2.SetActive(true);
        }*/
    }

    public void SiguienteA2()
    {
        

    }
}
