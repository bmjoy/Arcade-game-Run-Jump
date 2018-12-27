using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour {
	public GameObject[] obj;
	public float spawnMin ;
	public float spawnMax;
	// Use this for initialization
	void Start () {
		controleScene.resume = true;
		Spawn ();

	}
	
	public void Spawn(){
		float rand = Random.Range (0, 1000);
		float deltaD = Random.Range (-1, 1);
		if ( transform.position.x > 12 &&  rand > 300) {
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position+deltaD*Vector3.up, Quaternion.identity);
		}
		//Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
		if (controleScene.resume)
			Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
		else
			CancelInvoke ();
	}
}
