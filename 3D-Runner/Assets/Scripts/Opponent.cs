using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject TargetObject;
    public GameManager gm;

    public Transform StartPosition;

    public Animator anim;

    public float firstSpeed;
    bool finish;

    private Vector3 firstPos;
    
    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        finish = false;
        firstPos = transform.position;
        firstSpeed = OpponentAgent.speed;
    }

    
    void Update()
    {
        if (OpponentAgent.enabled!= false)
        {
            OpponentAgent.SetDestination(TargetObject.transform.position);
        }

        if (finish==true)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(firstPos.x, transform.position.y, 188f), 0.02f);
        }
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

        if (other.CompareTag("Finish"))
        {
            gm.RaceOver();
            finish = true;
            OpponentAgent.enabled = false;
            //new Vector3(firstPos.x, transform.position.y, 188f);
            if (gm.ScoreBoard[0].GetComponent<TextMeshProUGUI>().text == gameObject.name)
            {
                anim.SetTrigger("win");
            }

            else
            {
                anim.SetTrigger("lose");
            }
        }
    }

    public void NormalSpeed()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        OpponentAgent.speed -= 2.5f;
    }
}
