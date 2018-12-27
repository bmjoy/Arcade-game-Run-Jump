using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAudio : MonoBehaviour {
	public Button b;
	public  bool musicMute;
	public Sprite musicOn;
	public Sprite musicOff;

	public GameObject audioObject;
	AudioSource musicSource;

	// Use this for initialization
	void Start () {
		musicMute = false;
		musicSource=audioObject.GetComponent<AudioSource> ();
	}
	public void onClick(){
		if (musicMute) {
			b.image.sprite = musicOn;
			musicMute = false;
			musicSource.mute = false;
		} else {
			b.image.sprite = musicOff;
			musicMute = true;
			musicSource.mute = true;
		}
	}

}
