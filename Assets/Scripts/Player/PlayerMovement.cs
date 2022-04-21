using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("General Variables")]
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Sprint Variables")]
    [Tooltip("Key which will be used to activate sprinting")]
    public KeyCode sprintKey;

    [Tooltip("Controls the amount with which your initial speed will be multiplied by while sprinting")]
    public float sprintModifier = 1.5f;

    [Header("Ground Checking Variables")]
    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    [Header("Stamina Variables")]
    public float maxStamina = 100f;
    public float currentStamina = 100f;
    public float exhaustionSpeed = -0.2f;
    public float recoverySpeed = 0.4f;
    private const float cooldownTime = 3.0f;

    private bool isRecovering;

    // Cooldown coroutine so it takes time for stamina to start recharging
    IEnumerator Cooldown()
    {
        //isRecovering = false;
        yield return new WaitForSeconds(cooldownTime);
        isRecovering = true;
    }

    // Makes sure stamina will be maxed at the start of the game
    void Start()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
        // Checks if the player is grounded so they may jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
#pragma warning disable MissingReferenceException
        if (isGrounded && velocity.y < 0)
        {

            controller.slopeLimit = 45.0f;
            velocity.y = -2f;
            //Debug.Log("You are grounded");

        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Moving part
        Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);

        // Makes Running boolean be true when stamina is over 0 and sprint key is pressed
        bool isRunning = Input.GetKey(sprintKey) && currentStamina > 0;

        // Makes running possible provided stamina is over 0
        if (isRunning && currentStamina > 0)
        {
            controller.Move(move * speed * Time.deltaTime * sprintModifier);
            AdjustStamina(exhaustionSpeed);
        }

        // Starts cooldown coroutine if player is not running and stamina is under the maximum
        if (!isRunning && currentStamina < maxStamina)
        {
            StartCoroutine(Cooldown());
        }
        // Stops the (all) coroutine(s) when player starts running again so the stamina bar does not freak out
        // If not all coroutines are stopped, the stamina bar will start bugging and sometimes stopping in middle of it where another coroutine was started
        // so it just works to make it this way.
        else if (isRunning && Input.GetKeyDown(sprintKey))
        {
            StopAllCoroutines();
            //Debug.Log("Stopped Routine(s) on PlayerMovement Script");
        }
        // Adds stamina back if current stamina is under the maximum and the player is recovering and not running
        if (currentStamina < maxStamina && isRecovering && !isRunning)
        {
            AdjustStamina(recoverySpeed);
        }
        else
        {
            isRecovering = false;
        }

        // Jump script
        if (Input.GetButtonDown("Jump") && isGrounded && currentStamina > 0)
        {
            controller.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    // Stamina adjusting function
    private void AdjustStamina(float adjust)
    {
        currentStamina += adjust;

        // Makes sure stamina does not go under 0
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }

        // Makes sure stamina does not go over the maximum allowed
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }
}
