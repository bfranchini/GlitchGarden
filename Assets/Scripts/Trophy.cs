using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Trophy : MonoBehaviour
{
    public GameObject StarPrefab;

    public void CreateNewStar()
    {
        if (!StarPrefab)
        {
            Debug.LogError("Trophy is missing star prefab!!");
            return;
        }
        
        var starParent = GameObject.Find("FieldStars").transform;

        if (!starParent)
        {
            Debug.LogError("Could not find StarParents object");
            return;
        }

        var newStar = Instantiate(StarPrefab, starParent);

        //find the trophy's star child object so we can 
        //set the newly instantiated star's position to it.
        var children = GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.CompareTag("TrophyStar"))
            {
                var newStarPos = child.position;

                //Move these stars in front of everything so they're always clickable
                newStarPos.z = -1;
                newStar.transform.position = newStarPos;
     
                newStar.GetComponent<Star>().Speed = 0;
                return;
            }
        }


        Debug.LogError("Trophy could not find a child w/ tag 'TrophyStar'");
    }
}
