using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float fallSpeed = 5f;
    public float padding = 1f;
    public float horizontalVel = 6;
    public float verticalVel = 8;
    public float crouchTime = 0;
    public int lives = 3;

    //CROUCH MODIFIERS
    //vid's Note: These modify the time needed and force added when the player holds the jump button down.
    public float baseJumpModifier = 1;

    private Animator anim;

    public Rigidbody2D rb;
    public GameObject shredder;
    public GameObject platform;
    public SpawnPlatform spawnPlatform;

    public bool onWall = false;
    public bool onPlatform = false;
    public bool isJumping = false;

    bool flipped = false;
    bool firstJump = false;

    //bool gameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        AttachToPlatform();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (onPlatform)
            {
				anim.SetBool("isStanding", false);
                anim.SetBool("isCrouching", true);
            }
            else if (onWall)
            {
                anim.SetBool("isClinging", false);
				anim.SetBool("isJumping", false);
                anim.SetBool("isClingCrouching", true);
            }
			if (crouchTime < .5) {
				crouchTime += Time.deltaTime;
			}
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (onPlatform)
            {
                Jump();
                shredder.transform.position = new Vector3(0, -7, 0);
                anim.SetBool("isCrouching", false);
            }
            else if (onWall)
            {
                Jump();
				anim.SetBool("isCrouching", false);
                anim.SetBool("isClingCrouching", false);
            }
        }
     }

    void Jump()
    {
		anim.SetBool("isJumping", true);
        transform.parent = null;
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + Vector2.up * verticalVel * (crouchTime + baseJumpModifier);
        if (!flipped)
        {
            flipped = true;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + Vector2.right * -horizontalVel;
        }else
        {
            flipped = false;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + Vector2.left * -horizontalVel;
        }
        crouchTime = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isJumping", false);
        if (collision.gameObject.tag == "platform")
        {
            onPlatform = true;
        }
        else if (collision.gameObject.tag == "wall")
        {
            onWall = true;
            
            transform.Rotate(new Vector3(0, 180, 0));
            anim.SetBool("isClinging", true);

            //???
            rb.velocity = new Vector3(0, -fallSpeed, 0);
            print("collision!");
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if (collision.gameObject.tag == "shredder")
        {
            if (lives > 0)
            {
                shredder.transform.position = new Vector3(0, -12, 0);
                print("shredded");
                lives--;
                transform.position = new Vector3(0, -6, 0);
                AttachToPlatform();
				anim.SetBool("isJumping", false);
				anim.SetBool("isClinging", false);
				anim.SetBool("isClingCrouching", false);
				anim.SetBool("isCrouching", false);
				anim.SetBool("isStanding", true);
                spawnPlatform.Respawn();
                firstJump = false;
                flipped = !flipped;
            }
        }

       if (collision.gameObject.tag == "wall") {
        rb.velocity = new Vector3(0, -fallSpeed, 0);
        print("collision!");
        GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if (firstJump == false)
        {
            firstJump = true;
            transform.Rotate(new Vector3(0, 180, 0));
            
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
        if (collision.gameObject.tag == "platform")
        {
            onPlatform = false;
        }else if(collision.gameObject.tag == "wall")
        {
            onWall = false;
        }
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void AttachToPlatform()
    {
        this.transform.SetParent(platform.transform);
    }
}