using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class Ads : MonoBehaviour {

	public InterstitialAd interstitial;
	string adUnitId = "ca-app-pub-4533994226165679/2433146053";

	// Use this for initialization
	void Start () {
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		RequestInterstitial ();
	}

	public void RequestInterstitial(){
		
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}
	public void showAd()
	{
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}


}
