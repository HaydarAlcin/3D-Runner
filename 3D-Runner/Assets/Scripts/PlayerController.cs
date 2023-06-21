using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float firstSpeed;

    public float runningSpeed;
    public float xSpeed;

    public float limitX;

    public Animator PlayerAnim;
    public GameObject Player;
    private void Start()
    {
        firstSpeed = runningSpeed;

        PlayerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        SwipeCheck();
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
            runningSpeed = 0f;
        }
    }

    public void NormalSpeed()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        runningSpeed -= 2.5f;
    }
}
