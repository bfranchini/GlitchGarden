using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour 
{
	public int StarCost = 100;
    public float CoolDownPeriod = 5f;
    private StarDisplay starDisplay;	   
	
	void Start()
	{
		starDisplay = FindObjectOfType<StarDisplay>();
	}

	public void AddStars(int amount)
	{
		starDisplay.AddStars(amount);		
	}
}
