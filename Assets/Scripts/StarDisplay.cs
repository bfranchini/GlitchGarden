using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status{SUCCESS, FAILURE};
	private Text displayText;
    private int totalStars = 999;	
	
	// Use this for initialization
	void Start () 
	{		
		displayText = GetComponent<Text>();
		updateDisplay();
	}

	public void AddStars(int amount)
	{
		//add stars to display
		totalStars += amount;				
		updateDisplay();
	}
	
	public Status UseStars(int amount)
	{
		if(totalStars >= amount) 
		{
			//subtract stars from display
			totalStars -= amount;
			updateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;		
	}
	
	private void updateDisplay()
	{
		displayText.text = totalStars.ToString();
	}
}
