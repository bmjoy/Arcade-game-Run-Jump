using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour {

	public  GameObject loseWin; 
	public Text textUIscored;
	public Text textUItopScore;

	public GameObject audioObject;
	AudioSource musicSource;
	public GameObject controle;

	void OnTriggerEnter2D(Collider2D other){
		//if the object that triggered the event is tagged player
		if (other.tag == "Player") {
			musicSource=audioObject.GetComponent<AudioSource> ();
			musicSource.Pause();

			//Application.LoadLevel(1);
			//SceneManager.LoadScene (1);
			int topScore=(int)pancam.playerScore;
			controleScene.resume=false;
			if (PlayerPrefs.HasKey ("topScore")) {
				topScore = PlayerPrefs.GetInt ("topScore");
				if (pancam.playerScore > topScore) {
					PlayerPrefs.SetInt ("topScore", (int)pancam.playerScore);
					topScore = (int)pancam.playerScore;
				}
			} else {
				PlayerPrefs.SetInt ("topScore", topScore);
			}
			textUIscored.text = "your score: " + ((int)(pancam.playerScore)).ToString ();
			textUItopScore.text = "top Score: " + ((int)(topScore)).ToString ();

			loseWin.SetActive (true);

			controle.GetComponent<Ads> ().showAd ();
			controle.GetComponent<Ads> ().RequestInterstitial ();
		}

		if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);

		} else {
			Destroy (other.gameObject);		
		}
	}

}