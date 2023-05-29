using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Bulbos")) //Si el objeto que colisiona tiene el tag "Bulbos"
        {
            FollowTarget Anim = other.gameObject.GetComponent<FollowTarget>(); //activa el script y la bool de follow pastor
            Anim.animator.SetTrigger("Solaire");  // ademas activa la animacion de despertar
        }

        //AGUA
        if(other.gameObject.name == "puente") //Si el objeto que colisiona es un puente
        {

            GameObject nadadoresPadre =  GameObject.Find("SpawnerBulbosNAD");

            FollowTarget[] allChildren = nadadoresPadre.GetComponentsInChildren<FollowTarget>();
            foreach (FollowTarget child in allChildren)
            {
                child.irAObjectivo(other.gameObject);
            }
        }

    }

    void OnTriggerExit(Collider other) //si el objeto sale del trigger
    {
        if(other.gameObject.CompareTag("Bulbos")) //si el objeto tiene el tag "Bulbos"
        {
            other.gameObject.GetComponent<FollowTarget>().FollowPastor = true; //activa la bool de follow pastor
            other.gameObject.GetComponent<FollowTarget>().animator.ResetTrigger("Solaire"); //desactiva la animacion de despertar
        }




    }

}

