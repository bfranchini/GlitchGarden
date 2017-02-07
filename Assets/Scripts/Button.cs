using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class Button : MonoBehaviour
{
    public GameObject DefenderPrefab;
    private bool isActive;
    public static GameObject SelectedDefender;
    private Defender spawnableDefender;
    private Text costText;
    private float timeToSpawn;
    private StarDisplay starDisplay;
    private bool insufficientStars;
    private bool notReady;
    private Text tooltip;
	
	// Use this for initialization	
	void Start () 
	{
		//get all the buttons		

        costText = transform.FindChild("Cost").GetComponent<Text>();
        tooltip = transform.FindChild("Tooltip").GetComponent<Text>();

        isActive = false;
        spawnableDefender = DefenderPrefab.GetComponent<Defender>();
        starDisplay = FindObjectOfType<StarDisplay>();

        timeToSpawn = 0f;

		if(!costText)
		{
			Debug.LogWarning(name + " has no costText");
			return;
		}

	    if (!tooltip)
	    {
            Debug.LogWarning(name + " has no toolTip");
            return;
        }

		costText.text = spawnableDefender.StarCost.ToString();			 
	}
	
	// Update is called once per frame
	void Update ()
    {              
        timeToSpawn -= Time.deltaTime;
        
        if (IsButtonReady()) return;

        //if we have a defender selected but haven't deployed it don't let users click same button again
        if (SelectedDefender)
        {
            isActive = false;
            GetComponent<SpriteRenderer>().color = Color.black;
            return;
        }            

        if (notReady ||  insufficientStars) return;
        
        isActive = true;
        GetComponent<SpriteRenderer>().color = Color.white;        
    }

    private bool IsButtonReady()
    {
        //TODO: refactor this whole status checking block. It kind of sucks.
        if (starDisplay == null)
        {
            Debug.LogError("Defender buttons could not find StarDisplay!");
            return true;
        }

        var starCost = DefenderPrefab.GetComponent<Defender>().StarCost;

        //check if cooldown time has elapsed for this button
        if (timeToSpawn > 0)
        {
            notReady = true;
            tooltip.text = "Not Ready";
        }
        else
        {
            notReady = false;
            if (tooltip.text == "Not Ready")
                tooltip.text = null;
        }

        //check if we have enough stars to deploy this defender
        if (starCost > starDisplay.totalStars)
        {
            insufficientStars = true;
            tooltip.text = "Need Stars";
        }
        else
        {
            insufficientStars = false;

            if (tooltip.text == "Need Stars")
                tooltip.text = null;
        }
        return false;
    }

    void OnMouseDown()
	{
	    if (!isActive || SelectedDefender != null)
	    {	        
	        return;
	    }

	    GetComponent<SpriteRenderer>().color = Color.black;
	        
	    SelectedDefender = DefenderPrefab;

	    isActive = false;	    

	    timeToSpawn = DefenderPrefab.GetComponent<Defender>().CoolDownPeriod;
	}
}
