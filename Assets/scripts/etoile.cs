using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etoile : MonoBehaviour {

	pancam hud;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			hud = GameObject.Find ("Main Camera").GetComponent<pancam>();
			hud.increaseScore(10);
			Destroy (gameObject);
			//pancam.playerScore = +10;
		}
	}
}
