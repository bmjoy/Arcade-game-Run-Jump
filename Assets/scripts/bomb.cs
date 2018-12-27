using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {
	//a holder for our Animator
	Animator anim;
	//a public float for the explosion radius
	public float explodeRadius = 1f;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (controleScene.resume) {
			GetComponent <Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			anim.enabled=true;
			//if this bomb is spawned after the spawner reaches a position past x = 12
			if (transform.position.x > 10) {  //12
				this.gameObject.SetActive (true);
			}
			//otherwise bomb no worky
			else {
				this.gameObject.SetActive (false);
			}
			//if we are done exploding
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("bombdead")) {
				//destroy all the objects in a radius unless they are tagged Player or hand
				Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, explodeRadius);
				foreach (Collider2D col in colliders) {
					if (col.tag != "Player" && col.tag != "hand") {
						Destroy (col.GetComponent<Collider2D> ().gameObject);

					}
				}
				Destroy (this.gameObject);

			}
		} else {
			GetComponent <Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			anim.enabled=false;
		}
	}
}
