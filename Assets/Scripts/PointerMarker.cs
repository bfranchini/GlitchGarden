using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMarker : MonoBehaviour
{
    public Camera myCamera;
    private ParticleSystem particleSystem;
    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();

        if (particleSystem == null)
            Debug.LogError("Could not find pointer particle system!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.SelectedDefender != null)
        {            
            transform.position = SnapToGrid(CalculateWorldPointOfMouseClick());

            if (!particleSystem.isEmitting)
                particleSystem.Play();            
        }
        else
            particleSystem.Stop();
    }

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

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
