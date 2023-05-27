using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

public Collider collider;

void Awake() 
{
    collider.enabled = false;
}

void OnDisable() 
{
    collider.enabled = false;
}

void OnTriggerEnter(Collider other) 
{
    if(other.gameObject.CompareTag("Bulbos"))
    {
       other.gameObject.GetComponent<FollowTarget>().FollowPastor = true;
       Debug.Log("Bulbos");
    }
    Debug.Log("Trigger");
}

}
