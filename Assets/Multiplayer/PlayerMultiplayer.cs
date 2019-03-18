using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMultiplayer : MonoBehaviour
{
    public float speed = 15f;
    public PhotonView photonView;

    private float maxHeight = 3.8f;
    private float minHeight = -3.8f;
    private float verticalMovement;
    
    void Update()
    {
        if (photonView.IsMine)
        {
            verticalMovement = Input.GetAxisRaw("Vertical");
        }
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
