using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour 
{
	//private float widthScale;
	//private float heightScale;	
	//public int WidthTiles = 9;
	//public int HeightTiles = 5;
	
	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;
	
	// Use this for initialization
	void Start () 
	{	
		parent = GameObject.Find ("Defenders");
		
		if(!parent)
		{
			parent = new GameObject("Defenders");
		}
		
		starDisplay = FindObjectOfType<StarDisplay>();
	}
	
	void OnMouseDown()
	{					
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);	
		GameObject defender = Button.SelectedDefender;

        if (defender)
        {                        
            var defCost = defender.GetComponent<Defender>().StarCost;
            
            if (starDisplay.UseStars(defCost) == StarDisplay.Status.SUCCESS)
                SpawnDefender(roundedPos, defender);
            else
                Debug.Log("Not enough stars");
        }
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;
	    
		newDef.transform.parent = parent.transform;
        Button.SelectedDefender = null;
    }
	
	Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2(newX, newY);
	}
	
	//gets world units of where mouse was clicked
	Vector2 CalculateWorldPointOfMouseClick()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		
		//this distance is actually irrelevant since we're using an ortho camera
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);		
		
		return worldPos;//worldUnitsPosition;
	}
}
