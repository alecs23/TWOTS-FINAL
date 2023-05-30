using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalScript : MonoBehaviour
{
    public static int Nadadores = 0;
    public static int Robustos = 0;
    public static int Voladores = 0;
    public Texture2D IconoNadador;
    public Texture2D IconoRobusto;
    public Texture2D IconoVolador;
    int AnchoPantalla;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        AnchoPantalla = Screen.width/2;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnGUI() {
        GUI.DrawTexture (new Rect (20, 20, 80, 80), IconoNadador);
        GUI.DrawTexture (new Rect (20, 100, 80, 80), IconoRobusto);
        GUI.DrawTexture (new Rect (20, 180, 80, 80), IconoVolador);

    }
}
