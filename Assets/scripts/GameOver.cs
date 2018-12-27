using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	int score = 0;
	public Text textUI;

	// Use this for initialization
	void Start () {
		//get our score from playerprefs
		score = PlayerPrefs.GetInt ("Score");
		//multiply by 10 as we did on displayed score
		score = score * 10;
	}

	void OnGUI(){
		//set our text to our score
		textUI.text = score.ToString ();
		//if retry button is pressed load scene 0 the game
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +150,100,40),"Retry?")){
			Application.LoadLevel(0);
		}
		//and quit button
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +200,100,40),"Quit")){
			Application.Quit();
		}
	}

}
