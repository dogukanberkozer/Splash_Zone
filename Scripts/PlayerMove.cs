using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator; // required components
    Rigidbody2D rb2d;
    Vector2 velocity;

    [SerializeField] // to interfere via editor
    float speed = default; // player speed
    [SerializeField]
    float speedup = default; // player acceleration
    [SerializeField]
    float slowdown = default; // to reduce player speed
    [SerializeField]
    float jumpForce = default; // to reduce player speed
    [SerializeField]
    int jumpLimit = 4; // there is a limit to jump
    int jumpCounter;

    Joystick joystick;
    JoystickButton joystickBtn;
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // induction of the components
        rb2d = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>(); // find the object in Joystick type and assign to this variable
        joystickBtn = FindObjectOfType<JoystickButton>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControl();
        //JoystickControl();       
    }

    void JoystickControl()
    {
        float movementInput = joystick.Horizontal;
        Vector2 scale = transform.localScale; // to fix animation

        if(movementInput > 0) // right arrow or 'D' to move right
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, speedup * Time.deltaTime);
            // Mathf is a collection of common math functions
            animator.SetBool("Walk", true); // walk animation
            scale.x = 0.4f; // animation when start to move right
        }
        else if(movementInput < 0) // left arrow or 'A' to move left
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, speedup * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.4f; // used minus to fix animation when start to move left
        } else // when no input
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime); // the character will stop
            animator.SetBool("Walk", false); // walk animation is over

        }
        transform.localScale = scale; // to update fixed walking animation
        transform.Translate(velocity * Time.deltaTime); // updating the character speed       

        if(joystickBtn.isPressed == true && isJumping == false)
        {
            isJumping = true;
            StartJump();
        }

        if(joystickBtn.isPressed == false && isJumping == true)
        {
            isJumping = false;
            FinishJump();
        }
    }

    void KeyboardControl()
    {
        float movementInput = Input.GetAxisRaw("Horizontal"); // horizontal movements
        Vector2 scale = transform.localScale; // to fix animation

        if(movementInput > 0) // right arrow or 'D' to move right
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, speedup * Time.deltaTime);
            // Mathf is a collection of common math functions
            animator.SetBool("Walk", true); // walk animation
            scale.x = 0.4f; // animation when start to move right
        }
        else if(movementInput < 0) // left arrow or 'A' to move left
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, speedup * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.4f; // used minus to fix animation when start to move left
        } else // when no input
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, slowdown * Time.deltaTime); // the character will stop
            animator.SetBool("Walk", false); // walk animation is over

        }
        transform.localScale = scale; // to update fixed walking animation
        transform.Translate(velocity * Time.deltaTime); // updating the character speed

        if(Input.GetKeyDown("space")){ // when the space button is pressed
            StartJump();
        }

        if(Input.GetKeyUp("space")){ // if a hand is released from the space button
            FinishJump();
        }
    }

    void StartJump(){
        if(jumpCounter < jumpLimit)
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // AddForce needs 2 inputs as Vector and ForceMode
            animator.SetBool("Jump", true);
        }
    }

    void FinishJump()
    {
        animator.SetBool("Jump", false);
        jumpCounter++;
    }

    public void ResetJumpCounter()
    {
        jumpCounter = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            FindObjectOfType<GameControl>().FinishGame();
        }
    }
}