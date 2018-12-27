using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour {
	// a public object array for which objects to spawn
	public GameObject[] obj;
	//min and max times for another spawn
	public float spawnMin ;
	public float spawnMax;
	public float maxDelta ;
	public float minDelta ;

	void Start () {
		controleScene.resume = true;
		//start spawn 
		Spawn ();
	}

	public void Spawn(){
		//get random number
		float rand = Random.Range (0, 1000);
		float deltaD = Random.Range (minDelta, maxDelta);
		//if random number is greater than 700 make a bomb
		/*if (rand > 500) {
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position+deltaD*Vector3.right, Quaternion.identity);
		}*/
		Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position+deltaD*Vector3.right, Quaternion.identity);

		//invoke spawn at random time interval between min and max
		if (controleScene.resume)
			Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
		else
			CancelInvoke ();
		
	}

}