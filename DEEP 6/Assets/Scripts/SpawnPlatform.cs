using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionExit2D(Collision2D collision){
		anim.SetTrigger ("Descend");
	}

    public void Respawn()
    {
        anim.SetTrigger("Ascend");
    }
}
