using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	public WaveManager wm;

	//private Animator animator;
	private bool hasFired = false;
	private int bulletCount = 0;
	public float delayCount = 0;

    public bool isLastEnemy = false;

	void Start(){
		wm.IncrementEnemyCount ();
		//InvokeRepeating("FireDelay", 2.0f, 1f);
		InvokeRepeating("Fire", delayCount, 0.15f);

		//animator = GameObject.FindObjectOfType<Animator> ();

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
			newProjectile.transform.parent = projectileParent.transform;
			}
		}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "shredder") {
			Destroy (gameObject);
			wm.DecrementEnemyCount ();
            if(isLastEnemy == true)
            {
                print("Spawning New Wave");
				wm.SpawnWave ();
				wm.isLastEnemy = true;
            }
		}
	}
}
