using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etoileSpawner : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin ;
	public float spawnMax;

	// Use this for initialization
	void Start () {
		controleScene.resume = true;
		//start spawn 
		Spawn ();
	}
	public void Spawn(){
		float rand = Random.Range (0, 1000);
		if (rand > 500) {
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
		}
		//Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
		if (controleScene.resume)
			Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
		else
			CancelInvoke ();
	}
}
