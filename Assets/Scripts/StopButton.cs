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
		levelManager.LoadLevel("01a Start Menu");
	}
}
