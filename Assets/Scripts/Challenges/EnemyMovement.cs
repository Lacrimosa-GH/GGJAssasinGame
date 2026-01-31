using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;
    public Transform TurnPointCheck;
    public LayerMask TurnPointMask;
    
    

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (DetectTurnPoint())
        {
            moveSpeed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        }
    }
    

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }

    private bool DetectTurnPoint()
    {
        return Physics2D.OverlapCircle(TurnPointCheck.position, 0.1f, TurnPointMask);
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(TurnPointCheck.position, 0.1f);
    }
}
