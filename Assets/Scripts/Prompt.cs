using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResumeGame()
    {
        var prompt = GetComponent<Prompt>();

        if (!prompt)
        {
            Debug.LogError("Could not find Prompt script on Stop Prompt");
            return;            
        }

        prompt.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
