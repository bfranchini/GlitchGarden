using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//We're currently using an animation to control the fade. 
//This script will achieve the same result.
public class SceneFader : MonoBehaviour 
{
	public float FadeInTime; //Total time we want to fade over
	private Image fadeImage;
	private Color currentColor = Color.black;
															
	void Start () 
	{
		fadeImage = GetComponent<Image>();
	}
		
	void Update () 
	{
		//remove alpha so screen fades in from black		
		if(Time.timeSinceLevelLoad < FadeInTime )
		{
			//divide the FadeInTime into chunks based on how long the last frame lasted
			var decrement = Time.deltaTime / FadeInTime;
			currentColor.a -= decrement;
			fadeImage.color = currentColor;
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
