using System;
using UnityEngine;

public class input : MonoBehaviour
{
    
    private InputSystem_Actions _inputSystem;
    public float Move;
    public bool InteractPressed;

    private void Awake() => _inputSystem = new InputSystem_Actions();
    private void OnEnable() => _inputSystem.Enable();
    void OnDisable()=> _inputSystem.Disable();

    private void Update()
    {
        Move = _inputSystem.Player.Move.ReadValue<Vector2>().x;
        InteractPressed = _inputSystem.Player.Interact.WasPressedThisFrame();
    }
}
