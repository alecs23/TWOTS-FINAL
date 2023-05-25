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

    void Start()
    {
        CanvasLibro.SetActive(true);
        Pagina1.SetActive(false);
        Pagina2.SetActive(false);
        Pagina3.SetActive(false);
    }

    void Update()
    {
        
    }

    public void AbrirLibro()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Pagina1.SetActive(true);
        }
    }
}
