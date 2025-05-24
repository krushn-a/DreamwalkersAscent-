using System.IO;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //To access all the actions from the input action asset
    public InputActionAsset inputActions;

    //To access the movement action
    private InputAction Playermovement;

    //To access the player animator and rigidbody components
    private Animator PlayerAnimator;
    private Rigidbody2D PlayerRigidbody;

    //To set the speed of the player movement
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movementInput;
    private void OnEnable()
    {
        //Enabling the input action asset which is constantly monitored by the input system on every frame
        inputActions.FindActionMap("Player").Enable();

        Playermovement.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        Playermovement.canceled -= OnMoveCanceled;
        //Disable the input action asset
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        //Load the input action asset
        Playermovement = InputSystem.actions.FindAction("Move");
        //Get the rigidbody component
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        //Get the animator component
        PlayerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Read the movement input value
        movementInput = Playermovement.ReadValue<Vector2>();

        //Get the movement input from the input action
        PlayerRigidbody.linearVelocity = movementInput * moveSpeed;

        if(movementInput != Vector2.zero)
        {
            //Set the animator parameter to true if the player is moving
            PlayerAnimator.SetBool("isWalking", true);
            //Set the animator parameter to the movement input value
            PlayerAnimator.SetFloat("InputX", movementInput.x);
            PlayerAnimator.SetFloat("InputY", movementInput.y);
        }
        else
        {
            //Set the animator parameter to false if the player is not moving
            PlayerAnimator.SetBool("isWalking", false);
        }
    }

    // Callback for when the movement input is canceled
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Set "isWalking" to false when movement is canceled
        PlayerAnimator.SetBool("isWalking", false);
        //Set the animator parameter to the movement input value
        PlayerAnimator.SetFloat("LastInputX", movementInput.x);
        PlayerAnimator.SetFloat("LastInputY", movementInput.y);

    }
}
