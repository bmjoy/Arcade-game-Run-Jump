using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
	
	public AudioClip musicClip;
	public AudioSource musicSource;


	// Use this for initialization
	void Start () {
		musicSource= GetComponent<AudioSource> ();
		musicSource.clip = musicClip;
		musicSource.Play ();
	}
}
