using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController
    : MonoBehaviour
{
    private PlayerHide _playerHide;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private input _input;

    public float acceleration = 5.0f; // high number is slower acceleration
    public float deceleration = 2.0f; // low number is faster deceleration

    [SerializeField] private float _moveSpeed;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<input>();
        _animator = GetComponent<Animator>();
        _playerHide = GetComponent<PlayerHide>();
    }
    
    private void FixedUpdate()
    {
        // Debug.Log(_input.Move);
        float accelerator = deceleration;
        if (Math.Abs(_input.Move) > 0) {
            accelerator = acceleration;
        }
        _rigidbody2D.linearVelocityX += ((_input.Move * _moveSpeed) - _rigidbody2D.linearVelocityX) / accelerator;
        
        if (_input.Move > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // facing right
            
        }
        else if (_input.Move < 0)
        {
            
            transform.localScale = new Vector3(-1f, 1f, 1f); // facing left
            
        }
        
    }

    private void UpdateAnim()
    {
        if (_playerHide.UpdateHide()) _animator.Play("Crouch");
        
        else if (_input.Move != 0) _animator.Play("Walk");
        
        else _animator.Play("Idle");
    }

    private void Update()
    {
        UpdateAnim();
    }
}
