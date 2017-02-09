using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float LevelSeconds = 5;
	private AudioSource audioSource;
	//private float timeRemaining;
	private Slider slider;
	private LevelManager levelManager;
	private bool isEndOfLevel = false;
	private GameObject winMessage;
    private MusicManager musicManager;

	// Use this for initialization
	void Start ()
    {	
		slider = GetComponent<Slider>();
		levelManager = FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
        musicManager = FindObjectOfType<MusicManager>();
		findYouWin();
		winMessage.SetActive(false);	        	
	}
	
	// Update is called once per frame
	void Update ()
    {
		//time will progressively get closer to 1 which is slider max value
		slider.value = Time.timeSinceLevelLoad / LevelSeconds;
		
		if(Time.timeSinceLevelLoad >= LevelSeconds && !isEndOfLevel)
		{
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
        musicManager.StopMusic();
		audioSource.Play ();
		Invoke ("loadNextLevel", audioSource.clip.length);
		winMessage.SetActive (true);
		isEndOfLevel = true;
		DestroyAllTaggedObjects();
	}
	
	private void findYouWin()
	{
		winMessage = GameObject.Find ("WinMessage");
		
		if(!winMessage)
		{
			Debug.LogWarning("Please create WinMessage object");
		}
	}
	
	private void loadNextLevel()
	{
        musicManager.PlayMusic();
		levelManager.LoadNextLevel();
	}	
	
	//destroys all objects with DestroyOnWin tag
	private void DestroyAllTaggedObjects()
	{
		var objectsToDestroy = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		
		foreach(var gameObject in objectsToDestroy)
		{
			Destroy(gameObject);
		}
	}
	
	private void UpdateTimer()
	{
		//timeRemaining--;
		
		//move slider
		//slider.value = slider.value -(1.0f/LevelSeconds);
		
	}
}
