using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {
        if (this.gameObject.CompareTag("Obstacle"))
        {
            ObstacleRotate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Çarptý");
        }
    }


    public void ObstacleRotate()
    {
        transform.Rotate(new Vector3(0, rotateSpeed*Time.deltaTime, 0));
    }

}
