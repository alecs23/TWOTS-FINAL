using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
   
    public GameObject CanvasStart;
    public GameObject CanvasControles;

    
    void Start()
    {
        CanvasControles.SetActive(false);
        
    }

    
    void Update()
    {
        
    }

    public void EntrarJuego()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Controles()
    {
        CanvasStart.SetActive(false);
        CanvasControles.SetActive(true);
    }

    public void Volver()
    {
        CanvasStart.SetActive(true);
        CanvasControles.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    } 
}
