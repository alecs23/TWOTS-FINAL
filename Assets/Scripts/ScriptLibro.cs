using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptLibro : MonoBehaviour
{
    public GameObject CanvasLibro;
    public GameObject[] paginas;
    public int paginaActual = 0;
    public GameObject Pastor;

    void Start()
    {
        CanvasLibro.SetActive(true);
    }

    void Update()
    {
        // Abrir libro
        if (Input.GetKeyDown(KeyCode.I))
        {
            AbrirLibro();
        }

        // Cambiar a página siguiente
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CambiarPaginaSiguiente();
        }

        // Cambiar a página anterior
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CambiarPaginaAnterior();
        }

        // Cerrar libro
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarLibro();
        }

        // Estado pastor
        if (paginaActual > 0 && paginaActual < paginas.Length)
        {
            Pastor.GetComponent<PlayerMovement>().enabled = false; // Pastor no se mueve
        }
        else
        {
            Pastor.GetComponent<PlayerMovement>().enabled = true; // Pastor se mueve
        }
    }

    void AbrirLibro()
    {
        paginaActual = 0;
        MostrarPaginaActual();
    }

    void CambiarPaginaSiguiente()
    {
        paginaActual++;
        if (paginaActual >= paginas.Length)
        {
            paginaActual = paginas.Length - 1;
        }
        MostrarPaginaActual();
    }

    void CambiarPaginaAnterior()
    {
        paginaActual--;
        if (paginaActual < 0)
        {
            paginaActual = 0;
        }
        MostrarPaginaActual();
    }

    void MostrarPaginaActual()
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            if (i == paginaActual)
                {
                paginas[i].SetActive(true);
                 }
             else
                {
                paginas[i].SetActive(false);
                }
        }
}


    void CerrarLibro()
    {
        paginaActual = -1;
        MostrarPaginaActual();
    }
}

