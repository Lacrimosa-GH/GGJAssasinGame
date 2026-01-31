using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private input _input;
    private bool crouched = false;
    [SerializeField] private float _moveSpeed;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<input>();
        _animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = _input.Move * _moveSpeed;
        if (_input.Move > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // facing right
        }
        else if (_input.Move < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // facing left
        }
        
    }

    private void Update()
    {
        if (_rigidbody2D.linearVelocityX != 0)
        {
            _animator.SetTrigger("Walk");
        }
        else if (crouched)
        {
            _animator.SetTrigger("Crouch");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
    }
}
