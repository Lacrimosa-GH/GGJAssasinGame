using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;
    public Transform TurnPointCheck;
    public LayerMask TurnPointMask;

    private VisionDetect _visionDetect;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private EnemyDetection _enemyDetection;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _visionDetect = GetComponentInChildren<VisionDetect>();
        _enemyDetection = GetComponent<EnemyDetection>();
    }

    void Update()
    {
        if (DetectTurnPoint())
        {
            moveSpeed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1f, 1f);
        }

        UpdateAnimation();
    }
    

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }

    private bool DetectTurnPoint()
    {
        return Physics2D.OverlapCircle(TurnPointCheck.position, 0.1f, TurnPointMask);
    }

    private void UpdateAnimation()
    {
        if (_visionDetect.playerInView)
        {
            var originalSpeed = moveSpeed;
            moveSpeed = 0;
        }
        else if (!_visionDetect.playerInView && moveSpeed == 0)
        {
            _animator.Play("Idle");
        }
        else if (_rigidbody2D.linearVelocityX != 0)
        {
            _animator.Play("Walk");
        }
        else if (_enemyDetection.attackCooldown < Time.time) ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(TurnPointCheck.position, 0.1f);
    }
    
    
}
