using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject TargetObject;
    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        OpponentAgent.SetDestination(TargetObject.transform.position);
    }
}
