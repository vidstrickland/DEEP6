using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStatus : MonoBehaviour {

    public WaveManager wm;
    public bool isLastEnemy = false;
	
	// Update is called once per frame
	void CheckIfLastEnemy () {
		if(isLastEnemy == true)
        {
            wm.SpawnWave();
        }
	}
}
