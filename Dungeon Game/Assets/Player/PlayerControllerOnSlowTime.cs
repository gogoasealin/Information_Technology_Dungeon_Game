using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerOnSlowTime : MonoBehaviour {

    public float speed;
    private float dirX;
    private float dirY;
    private Rigidbody2D rb2d;
    public bool canJump;
    private GameObject gameController;
    private GameController gameControllerScript;
    public Joystick moveJoystick;
    private bool faceRight;
    public bool pause;
    public bool resume;
    private Quaternion movingLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion movingRight = Quaternion.Euler(0, 0, 0);
    private float verticalVelocity;
    public float jumpForce;
    public float jumpDistance;
    private bool playerOnJoystickPosition;
    public bool facingRight;
    public GameObject trowPosition;
    public GameObject trowPrefab;
    public bool canUseShuriken;
    private Animator anim;
    private bool slow;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        facingRight = true;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoJump();
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            DoJump();
        }
        if (canUseShuriken)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TrowShuriken();
            }
            if (CrossPlatformInputManager.GetButtonDown("Down"))
            {
                if (!slow)
                {
                    Time.timeScale = 0.95f;
                    Debug.Log(Time.timeScale);
                    Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
                    Debug.Log(Time.fixedDeltaTime);
                    slow = true;
                }
                else
                {
                    Time.timeScale = 1f;
                    Debug.Log(Time.timeScale);
                    Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
                    Debug.Log(Time.fixedDeltaTime);
                    slow = false;
                }
            }
        }
        //CheckPlayerPosition();
        //JoystickInvisible();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameControllerScript.SwitchPause();
        }
        if (pause)
        {
            gameControllerScript.Pause();
        }
        else if (!pause)
        {
            if (resume)
            {
                gameControllerScript.ResumeButton();
            }
        }
    }

    public void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX * speed * Time.deltaTime * 1, rb2d.velocity.y );
        Debug.Log(rb2d.velocity);
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
        if (other.gameObject.tag == "Ground")
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
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
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
