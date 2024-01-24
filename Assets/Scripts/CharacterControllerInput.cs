using UnityEngine;

public class CharacterControllerInput : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private float playerMaxSpeed = 6f;
    [SerializeField] private float accelerationSpeed = 2f;

    private CharacterController charController;
    private Vector2 currentMoveDir;
    private float _gravity = -9.81f;
    public float gravitymultiplier=1f;
    float vel = 0f;

    [SerializeField]
    private GameObject camera;
    private void Start()
    {
        // Initialize input manager and character controller
        charController = GetComponent<CharacterController>();
    }
    //
    public void HandleMovementInput(Vector2 moveDir)
    {
        //apply gravity
        if (charController.isGrounded && vel<0.00f)
        {
            vel = -1f;
        }
        else
        {
            vel += _gravity * gravitymultiplier * Time.deltaTime;
        }
        // Get player movement input from the input manager
        //Debug.Log(moveDir);
        // If the input is zero, stop player movement
        if (moveDir == Vector2.zero)
        {
            currentMoveDir = Vector2.zero;
        }
        else
        {
            // Accelerate towards the input direction
            currentMoveDir = Vector2.MoveTowards(currentMoveDir, moveDir,accelerationSpeed * Time.deltaTime);
        }
        /**
        // Calculate movement direction based on camera orientation
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Combine forward and right vectors to get the final move direction
        Vector3 moveDirection = cameraForward * currentMoveDir.y + cameraRight * currentMoveDir.x;
        moveDirection.Normalize();
        **/
        Vector3 forward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
        Vector3 moveDirection = forward* moveDir.y ;

        // Rotate the player towards the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 360f);
        }

        // Apply speed to the player's velocity
        Vector3 playerVelocity = moveDirection * moveDir.magnitude * playerMaxSpeed;
        playerVelocity.y = vel;

        // Move the player using the CharacterController
        MovePlayer(playerVelocity);
    }

    private void MovePlayer(Vector3 velocity)
    {
        // Move the player using CharacterController, taking deltaTime into account
        charController.Move(velocity * Time.deltaTime);
    }
}