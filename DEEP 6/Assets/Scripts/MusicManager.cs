﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		//audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
	}

	void OnLevelWasLoaded (int level) {

		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		Debug.Log("Playing Clip: " + thisLevelMusic);

		if (thisLevelMusic) { // If there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
