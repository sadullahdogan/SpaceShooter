using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject followTarget;
    public float dampeningFactor = 0.01f;
    private Vector3 offset;
    // Start is called before the first frame update
    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

    // Update is called once per frame
    void Update()
    {
        Vector3 newCamPos = new Vector3(
            transform.position.x,
            followTarget.transform.position.y,
           transform.position.z);
        SmoothMovement(newCamPos);
        //transform.position = new Vector3(player.transform.position.x,
        //                                  player.transform.position.y,
        //                                  transform.position.z);
    }
    public void SmoothMovement(Vector3 aTargetPosition)
    {
        offset += aTargetPosition;
        Vector3 oldPos = transform.position;
        Vector3 newPos = Vector3.LerpUnclamped(oldPos, aTargetPosition, dampeningFactor);
        transform.position = newPos;
        offset -= newPos - oldPos;
    }

}
