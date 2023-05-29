using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Animator animator;
    GameObject target; //target to follow
    UnityEngine.AI.NavMeshAgent nav; //reference to the navmesh agent

    public bool FollowPastor = false; //if true, the agent will follow the target, si esta en false pos no le sigue
    public bool FollowObjetivo = false; //if true, the agent will follow the target, si esta en false pos no le sigue

    // Start is called before the first frame update
        void Start()
    {
        animator = GetComponent<Animator>(); //llamamos al animator
        target = GameObject.Find("TargetFollowPlayer"); //buscamos el target
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>(); //
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", nav.velocity.magnitude); //segun la velocidad del pastor se activa el target (velocidad < 0.1f) o se activa el walk (velocidad > 0.1f))

           
        if(FollowPastor == false) //si no esta activado el follow, no hace nada
        {
            return;
        }
        
        //Dsaebug.Log(target.transform.position);
   
        nav.SetDestination(target.transform.position); //set the destination of the navmesh agent to the target position

        //LOOK AT TARGET
        //transform.LookAt(target.transform);

    }


    public void irAObjectivo(GameObject objectivo){

        if(FollowPastor == false) return;

        target = objectivo;



    }

}
