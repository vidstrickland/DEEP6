﻿using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, -scrollSpeed/30, 0);
	}
}
