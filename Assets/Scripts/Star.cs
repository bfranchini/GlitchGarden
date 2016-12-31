using System;
using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{
    public int Value = 25;
    public float Speed = 1;    
    public AudioClip ClickSound;
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    // Update is called once per frame
    void Update ()
    {
	    transform.Translate(Vector3.down * Speed * Time.deltaTime);
	}

    void OnMouseDown()
    {
        starDisplay.AddStars(Value);
        
        if(ClickSound)
            AudioSource.PlayClipAtPoint(ClickSound, transform.position);
        else
            Debug.LogError("Star is missing ClickSound");

        Destroy(gameObject);
    }
}
