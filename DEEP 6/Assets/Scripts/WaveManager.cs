using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public GameObject[] waveArray;
	public int enemyCount = 0;

	// Use this for initialization
	void Start () {
		ResetEnemyCount ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncrementEnemyCount(){
		enemyCount++;
		print ("Count++!" + enemyCount);
	}

	public void DecrementEnemyCount(){
		enemyCount--;
		print ("Count--!" + enemyCount);
	}
	private void ResetEnemyCount(){
		enemyCount = 0;
		print ("Enemy Count Reset to " + enemyCount);
	}
}
