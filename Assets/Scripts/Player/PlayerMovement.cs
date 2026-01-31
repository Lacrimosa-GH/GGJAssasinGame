using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private input _input;
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
    }

    private void Update()
    {
            
    }
}
