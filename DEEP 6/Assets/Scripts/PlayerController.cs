using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float fallSpeed = 5f;
	public float padding = 1f;
	public float horizontalVel = 6;
	public float verticalVel = 8;
	public float crouchTime = 0;

	//CROUCH MODIFIERS
	//vid's Note: These modify the time needed and force added when the player holds the jump button down.
	public float baseJumpModifier = 1;

	private Animator anim;

	public Rigidbody2D rb;

	public GameObject platform;

	bool colliding = false;
	bool flipped = false;
	bool firstJump = false;

	//bool gameStarted = false;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		AttachToPlatform ();
	}

	void Update () {
		if (Input.GetMouseButton(0)) {
			anim.SetTrigger ("Crouch Trigger");
			crouchTime += Time.deltaTime;
		}

		if (((Input.GetMouseButtonUp(0)) && colliding) && !flipped) {
			anim.SetTrigger ("Jump Trigger");
			transform.parent = null;
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity + Vector2.up * verticalVel * (crouchTime + baseJumpModifier);
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity + Vector2.right * -horizontalVel;
			crouchTime = 0;
			firstJump = true;
			flipped = true;

		}else if(((Input.GetMouseButtonUp(0)) && colliding) && flipped){
			anim.SetTrigger ("Jump Trigger");
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity + Vector2.up * verticalVel * (crouchTime + baseJumpModifier);
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity + Vector2.left * -horizontalVel;
			crouchTime = 0;

			flipped = false;
		}
	}

	public void AttachToPlatform(){
		this.transform.SetParent (platform.transform);
	}

	void OnCollisionEnter2D(Collision2D collision){
		rb.velocity = new Vector3(0, -fallSpeed, 0);
		print("collision!");
		colliding = true;
		GetComponent<Rigidbody2D>().gravityScale = 0;

		if (firstJump = true) {
			transform.Rotate (new Vector3 (0, 180, 0));
		}

	}
	void OnCollisionExit2D(Collision2D collision){
		colliding = false;
		print("not collision!");
		GetComponent<Rigidbody2D>().gravityScale = 1;
	}
}