using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBeam : MonoBehaviour {

	private Animator anim;
	public float timeUntilThinBeam;
	public float timeUntilWidenBeam;
	public float timeUntilCharge1;
	public float timeUntilCharge2;
	public float timeUntilCharge3;
	public float timeUntilCharge4;
	public float timeUntilRetract;
	public float timeUntilFireBeam;
	public float timeUntilHoldBeam;
	public float timeUntilEndBeam;
	private float playerPos;
	private float cannonPos;
	private bool hasCharged = false;
	private bool hasFired = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

		Invoke("ThinBeam", timeUntilThinBeam);
		Invoke("WidenBeam", timeUntilWidenBeam);
		Invoke("Charge1", timeUntilCharge1);
		Invoke("Charge2", timeUntilCharge2);
		Invoke("Charge3", timeUntilCharge3);
		Invoke("Charge4", timeUntilCharge4);
		Invoke("Retract", timeUntilRetract);
		Invoke("FireBeam", timeUntilFireBeam);
		Invoke("HoldBeam", timeUntilHoldBeam);
		Invoke("EndBeam", timeUntilEndBeam);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position.y;
		cannonPos = transform.position.y;

		if (!hasCharged) {
			if (playerPos > cannonPos) {
				transform.parent.position += new Vector3 (0, 4, 0) * Time.deltaTime;
			} else {
				transform.parent.position += new Vector3 (0, 2, 0) * Time.deltaTime;
			}
		} else if (!hasFired) {
			transform.parent.position += new Vector3 (0, 3, 0) * Time.deltaTime;
		} else {
			transform.parent.position += new Vector3 (0, 0, 0) * Time.deltaTime;
		}
	}

	void ThinBeam(){
		anim.SetBool("thinBeam", true);
	}

	void WidenBeam(){
		anim.SetBool ("widenBeam", true);
		anim.SetBool("thinBeam", false);
	}
	void Charge1(){
		anim.SetBool ("charge1", true);
		anim.SetBool("widenBeam", false);
	}
	void Charge2(){
		anim.SetBool ("charge2", true);
		anim.SetBool("charge1", false);
	}
	void Charge3(){
		anim.SetBool ("charge3", true);
		anim.SetBool("charge2", false);
	}
	void Charge4(){
		anim.SetBool ("charge4", true);
		anim.SetBool("charge3", false);
	}
	void Retract(){
		anim.SetBool ("retract", true);
		anim.SetBool("charge4", false);
		hasCharged = true;
	}
	void FireBeam(){
		anim.SetBool ("fireBeam", true);
		anim.SetBool("retract", false);
	}
	void HoldBeam(){
		anim.SetBool ("holdBeam", true);
		anim.SetBool("fireBeam", false);
	}
	void EndBeam(){
		anim.SetBool ("endBeam", true);
		anim.SetBool("holdBeam", false);
		hasFired = true;
	}
}
