using UnityEngine;
using UnityEngine.SceneManagement;

public class controleScene : MonoBehaviour
{
	public GameObject pauseWin;
	public GameObject audioObject;
	AudioSource musicSource;
	public static bool resume;
	public GameObject[] bombSources;
	BombSpawner[] bombSpawner;

	void Start () {
		controleScene.resume = true;

		if(SceneManager.GetActiveScene().name.Equals("g")){
			musicSource=audioObject.GetComponent<AudioSource> ();
			int i = 0;
			bombSpawner = new BombSpawner[bombSources.Length];
			foreach( GameObject source in bombSources){
				bombSpawner[i]=source.GetComponent<BombSpawner> ();
				i++;
			}
		}
	}

	public void LoadScene(string sceneName)
	{
		pancam.playerScore = 0;
		SceneManager.LoadScene(sceneName);
	}
	public void setActivePauseWin(bool b){
		resume = !b;
		if (b) {
			foreach( BombSpawner source in bombSpawner){
				source.CancelInvoke();
			}
			pauseWin.SetActive (b);
			musicSource.Pause();
		}
		else{
			((CanvasController)pauseWin.GetComponent<CanvasController>()).FadeOut ();
			musicSource.Play();
			foreach( BombSpawner source in bombSpawner){
				source.Spawn ();
			}
		}
	}

}
