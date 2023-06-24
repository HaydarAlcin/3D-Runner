using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    public Transform cameraTarget;
    public float sSpeed = 10.0f;

    public Vector3 distance;
    public Transform lookTarget;

    public PlayerController pc;
    Vector3 finishPos;

    private void Start()
    {
        finishPos = new Vector3(1f, 4.62f, 198f);
    }

    private void LateUpdate()
    {

        if (pc.finish==false)
        {
            Vector3 dPos = cameraTarget.position + distance;
            Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
            transform.position = sPos;
        }
        else if (pc.finish==true)
        {
            transform.position = Vector3.Lerp(transform.position,finishPos,sSpeed*Time.deltaTime);
        }
        
        transform.LookAt(lookTarget.position);

    }


}
