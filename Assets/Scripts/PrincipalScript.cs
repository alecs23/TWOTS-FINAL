using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalScript : MonoBehaviour
{
    public static int Nadadores = 0;
    public static int Robustos = 0;
    public static int Voladores = 0;
    public GUISkin miSkin;
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
        GUI.skin = miSkin;
        GUI.Label(new Rect(20, 20, 150, 120),"Nadadores: "+Nadadores.ToString(), "estiloScore");
        GUI.Label(new Rect(20, 80, 150, 120),"Robustos: "+Robustos.ToString(), "estiloScore");
        GUI.Label(new Rect(20, 140, 150, 120),"Voladores: "+Voladores.ToString(), "estiloScore");
        GUI.DrawTexture (new Rect (Screen.width-120, 20, 80, 80), IconoNadador);
        GUI.DrawTexture (new Rect (Screen.width-120, 100, 80, 80), IconoRobusto);
        GUI.DrawTexture (new Rect (Screen.width-120, 180, 80, 80), IconoVolador);

    }
}
