using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
            
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = false;
			music.Play();
		}		
	}

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        
        Debug.Log(scene.buildIndex);
        LoadMusicPlayer(scene.buildIndex);
    }

    void LoadMusicPlayer (int level)
	{
		Debug.Log ("music player loaded level " + level);
		music.Stop();
		
		switch(level)
		{
			case 0:
			{
				music.clip = startClip;
				break;
			}
			case 1: 
			{
				Debug.Log("load game clip");
				music.clip = gameClip;
				break;
			}
			case 2: 
			{
				music.clip = endClip;
				break;
			}
			default:
			{
				music.clip = null;
				break;
			}
		}	
		
		music.Play();
	}
}
