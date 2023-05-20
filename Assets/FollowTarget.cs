using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    GameObject target;
    UnityEngine.AI.NavMeshAgent nav; 

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("TargetFollowPlayer");
        nav.SetDestination(target.transform.position);

        //LOOK AT TARGET

        // transform.LookAt(target.transform);
    }
}
