using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject TargetObject;

    public Transform StartPosition;


    public float firstSpeed;

    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();

        firstSpeed = OpponentAgent.speed;
    }

    
    void Update()
    {
        OpponentAgent.SetDestination(TargetObject.transform.position);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, StartPosition.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            OpponentAgent.speed += 2.5f;
            Invoke("NormalSpeed", 2f);
        }
    }

    public void NormalSpeed()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        OpponentAgent.speed -= 2.5f;
    }
}
