using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	public GameObject[] waveArray;
	public int enemyCount = 0;
    public int waveCount = 0;

    private GameObject wave;
    private GameObject currentWave;

    // Use this for initialization
    void Start () {
        Reset();
        SpawnWave();
    }
	
	// Update is called once per frame
	void Update () {
    
	}

    public void SpawnWave()
    {
        //Create the wave
        currentWave = Instantiate(waveArray[waveCount]) as GameObject;

        //Position it at 0,0,0 (please build waves assuming they appear at 0,0,0)
        currentWave.transform.position = new Vector3(0, 0, 0);

        //Increment current wave number
        waveCount++;
        print("Wave Count: " + waveCount);
    }

    public void EndWave()
    {
        //Destroy(currentWave);
    }

	public void IncrementEnemyCount(){
		enemyCount++;
		print ("Count++!" + enemyCount);
	}

	public void DecrementEnemyCount(){
		enemyCount--;
		print ("Count--!" + enemyCount);
	}
	private void Reset(){
		enemyCount = 0;
        waveCount = 0;
		print ("Enemy Count Reset to " + enemyCount);
	}
}
