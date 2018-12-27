using UnityEngine;
using System.Collections;

public class tonne : MonoBehaviour {
	public float explodeRadius = 2f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (controleScene.resume) {
			GetComponent <Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			//if this bomb is spawned after the spawner reaches a position past x = 12
			if (transform.position.x > 10) {
				this.gameObject.SetActive (true);
			}
			//otherwise bomb no worky
			else{
				this.gameObject.SetActive (false);
			}
			Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position,explodeRadius);
			foreach(Collider2D col in colliders){
				if (col.tag == "line"){
					Destroy(col.GetComponent<Collider2D>().gameObject);

				}
			}
		} else {
			GetComponent <Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		}

	}

}
