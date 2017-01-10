using UnityEngine;
using System.Collections;

public class WallScroller : MonoBehaviour {

	public float scrollSpeed = .5f;
	float offset;
	float rotate;

	void Update (){
		offset+= (Time.deltaTime*scrollSpeed)/10.0f;
		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2(0, offset));

	}
}
