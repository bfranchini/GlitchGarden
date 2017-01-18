using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour 
{
	private LevelManager levelManager;
	
	void Start()
	{
		levelManager = FindObjectOfType<LevelManager>();
	}	
	
	void OnMouseDown()
	{
	    var promptsParent = GameObject.Find("Prompts");

	    if (!promptsParent)
	    {
	        Debug.LogError("Could not find prompts parent object!");
            return;	        
	    }

	    var stopPrompt = promptsParent.transform.Find("StopPrompt");

        if (!stopPrompt)
        {
            Debug.LogError("Could not find stop prompt!");
            return;
        }

        stopPrompt.gameObject.SetActive(true);
        
        //pause the game
        Time.timeScale = 0;       
    }
}
