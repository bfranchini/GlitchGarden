using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour 
{
	public GameObject DefenderPrefab;
	public static GameObject SelectedDefender;
	private Button[] buttonArray;	
	private Text costText;
	
	// Use this for initialization
	void Start () 
	{
		//get all the buttons
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();	
		
		if(!costText)
		{
			Debug.LogWarning(name + " has no costText");
			return;
		}
		
		costText.text = DefenderPrefab.GetComponent<Defender>().StarCost.ToString();			 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{							
		//iterate through all the buttons and reset their color to black
		foreach(var button in buttonArray)
		{
			button.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		//get sprite renderer of object we just clicked on to black
		GetComponent<SpriteRenderer>().color = Color.white;;	
		
		SelectedDefender = 	DefenderPrefab;	
	}
}
