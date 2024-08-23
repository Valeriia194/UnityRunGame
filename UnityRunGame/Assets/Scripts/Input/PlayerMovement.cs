using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed;
    private PlayerInput pi;
    public Vector2 MovementDirection => pi.Player.Movement.ReadValue<Vector2>();
    void Start()
    {
        pi = new PlayerInput();
        pi.Enable();
        pi.Player.Movement.Enable();
        pi.Player.Jump.performed += OnJump;
     }

    public void Init(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 nextPosition = pi.Player.Movement.ReadValue<Vector2>() * movementSpeed * Time.fixedDeltaTime;
        var direction = new Vector3(nextPosition.x, 0, nextPosition.y);
        transform.position += direction;
        transform.forward = direction == Vector3.zero ? transform.forward : direction;
    }

    private void OnJump (InputAction.CallbackContext context)
    {
        transform.position += Vector3.up;
    }
}
