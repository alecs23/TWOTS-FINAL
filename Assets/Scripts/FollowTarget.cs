using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    GameObject target;
    UnityEngine.AI.NavMeshAgent nav; 

    public bool FollowPastor = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("TargetFollowPlayer");
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

   
    void Update()
    {

        if(FollowPastor == false)
        {
            return;
        }

        nav.SetDestination(target.transform.position);

        //LOOK AT TARGET

        // transform.LookAt(target.transform);
    }
}
