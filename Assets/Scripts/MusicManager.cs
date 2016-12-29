using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;	
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log("Don't destroy on load: " + name);
	}
	
	// Use this for initialization
	void Start () 
	{		
		audioSource = GetComponent<AudioSource>();		
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
        LoadMusicManager(scene.buildIndex);
    }

    private void LoadMusicManager(int level)
	{
		Debug.Log("Playing clip: " + levelMusicChangeArray[level]);
		var thisLevelMusic = levelMusicChangeArray[level];
		
		if(thisLevelMusic)
		{					
			audioSource.volume = PlayerPrefsManager.GetMasterVolume();	
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
