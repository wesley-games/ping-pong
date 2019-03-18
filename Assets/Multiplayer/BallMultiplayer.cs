using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMultiplayer : MonoBehaviour
{
    public float speed = 0.08f;
    public Rigidbody2D rb;

    private string tagRight = "GoalRight";
    private string tagLeft = "GoalLeft";

    void Start()
    {
        string tag = Random.Range(0, 1) == 0 ? tagRight : tagLeft;
        StartCoroutine(Launch(tag));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StopAllCoroutines();
        if (collider.tag == tagRight)
        {
            StartCoroutine(Launch(collider.tag));
        }
        if (collider.tag == tagLeft)
        {
            StartCoroutine(Launch(collider.tag));
        }
    }

    IEnumerator Launch(string tag)
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-70f, 70f));
        Vector3 force = (tag == tagRight ? transform.right : -transform.right) * speed;
        yield return new WaitForSeconds(2);
        rb.AddForce(force);
    }
}
