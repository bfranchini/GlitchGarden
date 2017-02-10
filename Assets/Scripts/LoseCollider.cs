using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
    private MusicManager musicManager;
	
	void Start()
	{
		levelManager = FindObjectOfType<LevelManager>();
        musicManager = FindObjectOfType<MusicManager>();
	}
	
	void OnTriggerEnter2D()
	{	
        //stop main music so we can play lose jingle
        musicManager.StopMusic();	

		if(levelManager)
			levelManager.LoadLevel("03b lose");		
			
		Debug.Log("Level manager not found in LoseCollider");
	}

}
