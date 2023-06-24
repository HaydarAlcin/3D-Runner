using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float firstSpeed;

    public float runningSpeed;
    public float xSpeed;
    public bool finish;

    public float limitX;
    private Vector3 firstPos;

    public Animator PlayerAnim;
    public GameManager gm;
    private void Start()
    {
        firstSpeed = runningSpeed;
        finish = false;
        firstPos = transform.position;
    }

    private void Update()
    {
        SwipeCheck();

        if (finish == true)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(firstPos.x, transform.position.y, 188f), 0.02f);
        }
    }


    void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            runningSpeed += 2.5f;
            Invoke("NormalSpeed",2f);
        }

        else if (other.CompareTag("Finish"))
        {
            gm.RaceOver();
            finish = true;
            runningSpeed = 0f;
            if (gm.ScoreBoard[0].GetComponent<TextMeshProUGUI>().text == gameObject.name)
            {
                PlayerAnim.SetTrigger("win");
            }

            else
            {
                PlayerAnim.SetTrigger("lose");
            }
        }
    }

    public void NormalSpeed()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        runningSpeed -= 2.5f;
    }
}
