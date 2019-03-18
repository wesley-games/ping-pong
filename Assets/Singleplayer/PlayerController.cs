using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;

    private float maxHeight = 3.8f;
    private float minHeight = -3.8f;
    private float verticalMovement;
    
    void Update()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if ((verticalMovement > 0 && transform.position.y < maxHeight)
            || (verticalMovement < 0 && transform.position.y > minHeight))
        {
            transform.Translate(Vector3.up * verticalMovement * speed * Time.deltaTime);
        }
    }
}
