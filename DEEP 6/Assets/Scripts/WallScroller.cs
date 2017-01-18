using UnityEngine;
using System.Collections;

public class WallScroller : MonoBehaviour {

	//Level Speed must match Jolene's Fall Speed!
	public float levelSpeed = 3;

	float offset;
	float rotate;
	float scrollSpeed;

	void Start(){
		scrollSpeed = levelSpeed * 10;
	}

	void FixedUpdate (){
		offset+= (Time.deltaTime*scrollSpeed)/10.0f;
		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2(0, offset));

	}
}
