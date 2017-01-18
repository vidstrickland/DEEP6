using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public GameObject currentWave;
	public GameObject[] waveArray;
	public int enemyCount = 0;
    public int waveCount = 0;
	public bool isLastEnemy = false;

    

    // Use this for initialization
    void Start () {
        //Reset();
        SpawnWave();
    }
	
	// Update is called once per frame
	void Update () {
		/*if (isLastEnemy == true) {
			SpawnWave ();
			isLastEnemy = false;
		}*/
	}

    public void SpawnWave()
    {
        //Create the wave
		GameObject newWave = Instantiate(waveArray[waveCount]) as GameObject;

		Shooter[] shooterArray = newWave.GetComponentsInChildren<Shooter> ();

		foreach(Shooter shooter in shooterArray){
			shooter.wm = this;
		}


        //Position it at 0,0,0 (please build waves assuming they appear at 0,0,0)
        //currentWave.transform.position = new Vector3(0, 0, 0);

        //Increment current wave number
        waveCount++;
        print("Wave Count: " + waveCount);
    }

    public void EndWave()
    {
        //Destroy(currentWave);
    }

	public void IncrementEnemyCount(){
		enemyCount+=1;
		print ("Count++!" + enemyCount);
	}

	public void DecrementEnemyCount(){
		enemyCount-=1;
		print ("Count--!" + enemyCount);
	}
	private void Reset(){
		enemyCount = 0;
        waveCount = 0;
		print ("Enemy Count Reset to " + enemyCount);
	}
}
