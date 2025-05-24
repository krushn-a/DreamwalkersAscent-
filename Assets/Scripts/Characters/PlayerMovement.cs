using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //To access all the actions from the input action asset
    public InputActionAsset inputActions;

    //To access the movement action
    private InputAction Playermovement;

    private Rigidbody2D PlayerRigidbody;
    [SerializeField] private float moveSpeed = 5f;

    private void OnEnable()
    {
        //Enabling the input action asset which is constantly monitored by the input system on every frame
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        //Disable the input action asset
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        //Load the input action asset
        Playermovement = InputSystem.actions.FindAction("Move");
        //Get the rigidbody component
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerRigidbody.linearVelocity = Playermovement.ReadValue<Vector2>() * moveSpeed;
    }
}
