using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPCController : MonoBehaviour
{
    public GameObject ball;
    public float pcSpeed = 0.2f;

    private float maxHeight = 3.8f;
    private float minHeight = -3.8f;

    private float yTrack;
    private float timeTrack = 0.01f;
    private float timeCount = 0f;
    
    void Update()
    {
        if (timeCount > timeTrack)
        {
            yTrack = ball.transform.position.y;
            timeCount = 0;
        }
        else
        {
            timeCount += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yTrack, 0), pcSpeed);
    }
}
