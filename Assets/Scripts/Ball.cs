using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D rb;
    private LineRenderer lr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    void Start()
    {
        GameController.RegisterBall(this);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void DrawForceVector(Vector2 force)
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + new Vector3(force.x, force.y, 0));
        lr.enabled = true;
    }

    public void DisableForceVector()
    {
        lr.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Replicator>() != null)
        {
            GameController.SpawnBall(transform.position, rb.velocity);
            Destroy(other.gameObject);
        }
    }
}
