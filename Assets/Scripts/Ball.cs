using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D Rigidbody;
    [HideInInspector] public Collider2D Collider;

    [HideInInspector] public Vector3 BallPosition { get { return transform.position; } }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }

    public void Push(Vector2 force)
    {
        Rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRigidbody()
    {
        Rigidbody.isKinematic = false;
    }

    public void DesactivateRigidbody()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = 0f;
        Rigidbody.isKinematic = true;
    }
}
