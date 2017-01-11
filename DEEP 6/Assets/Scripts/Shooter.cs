using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private bool hasFired = false;
	private int bulletCount = 0;
	public int delayCount = 0;

	void Start(){
		//InvokeRepeating("FireDelay", 2.0f, 1f);
		InvokeRepeating("Fire", delayCount, 0.3f);

		animator = GameObject.FindObjectOfType<Animator> ();

		//creates a parent if neccessary
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}
	void Update(){
		if (hasFired) {
			//animator.SetBool ("isAttacking", true);
			//Fire();
		} else {
			//animator.SetBool ("isAttacking", false);
		}
	}
		
	private void FireDelay(){
		hasFired = !hasFired;
	}

	private void Fire(){
		bulletCount++;
		if (bulletCount <= 3) {
			GameObject newProjectile = Instantiate (projectile)  as GameObject;
			newProjectile.transform.rotation = projectileParent.transform.rotation;
			newProjectile.transform.rotation = gun.transform.rotation;
			newProjectile.transform.position = gun.transform.position;
			}
		}
	}
