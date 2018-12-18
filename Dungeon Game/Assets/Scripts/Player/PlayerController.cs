using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float dirX;
    public float dirY;
    private Rigidbody2D rb2d;
    public bool canJump;
    private GameObject gameController;
    private GameController gameControllerScript;
    public Joystick moveJoystick;


    private Quaternion movingLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion movingRight = Quaternion.Euler(0, 0, 0);
    private float verticalVelocity;
    public float jumpForce ;
    public float jumpDistance;
    private bool playerOnJoystickPosition;
    private Animator anim;
    public bool facingRight;
    public GameObject trowPosition;
    public GameObject trowPrefab;
    [SerializeField] bool notUseShuriken;




    void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        facingRight = true;
        anim = GetComponent<Animator>();
    }


    void Update() {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dirX = moveJoystick.InputDirection.x * speed;
            if (dirX < 0)
            {
                gameObject.transform.rotation = movingLeft;
                facingRight = false;
            }
            else
            {
                gameObject.transform.rotation = movingRight;
                facingRight = true;
            }
            anim.SetBool("Moving", true);
        }
        else
        {
            dirX = 0;
            anim.SetBool("Moving", false);
        }

        if (dirX == 0)
        {
            dirX = Input.GetAxis("Horizontal");
        }
        if (Input.GetKeyDown(KeyCode.Space)) // removable
        {
            DoJump();
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            DoJump();
        }
        if (Input.GetKeyDown(KeyCode.E))  // removable
        {
            TrowShuriken();
        }
        if (CrossPlatformInputManager.GetButtonDown("Attack") && !notUseShuriken)
        {
            TrowShuriken();
        }


    }

    public void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX * speed, rb2d.velocity.y);
    }

    public void DoJump()
    {
        if (canJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + jumpDistance, jumpForce);
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            canJump = true;
        }else if(other.gameObject.tag == "Climbable")
        {
            canJump = true;
        }
        if (other.gameObject.tag == "Enemy")
        {
            gameControllerScript.GameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }else if (other.gameObject.tag == "Climbable")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }
        else if (other.gameObject.tag == "Climbable")
        {
            canJump = false;
        }
    }
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        gameControllerScript.GameOver();
    }

    private void TrowShuriken()
    {
        Instantiate(trowPrefab, trowPosition.transform.position, Quaternion.identity);
    }
}
