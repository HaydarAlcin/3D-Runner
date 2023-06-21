using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float obstacleSpeed;
    
    private float randomOffset;
    public float strength = 2.5f;


    private void Start()
    {
        randomOffset = Random.Range(-strength, strength);
    }


    private void Update()
    {
        Move();
        
    }


    public void Move()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Sin(Time.time * obstacleSpeed * randomOffset) * strength;
        transform.position = pos;
    }
}
