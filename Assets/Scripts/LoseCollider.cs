using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D()
	{		
		if(levelManager)
			levelManager.LoadLevel("03b lose");		
			
		Debug.Log("Level manager not found in LoseCollider");
	}

}
