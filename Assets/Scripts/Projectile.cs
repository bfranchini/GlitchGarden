using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float Speed, Damage;
    public AudioClip audioClip;

	// Use this for initialization
	void Start () {	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		
			//get the gameObject of the collider we just hit
			var obj = collider.gameObject;		

			//get the health and attacker components of the game object we just grabbed
			var attackerHealth = obj.GetComponent<Health>();
			var attacker = obj.GetComponent<Attacker>();
			
			//deal damage only if we hit an attacker																
			if(attacker && attackerHealth)
			{
			    PlaySoundEffect();
                attackerHealth.DealDamage(Damage);			
				Destroy(gameObject);
			}					
	}

    private void PlaySoundEffect()
    {
        if (audioClip == null)
        {
            Debug.LogError("Audio clip on " + name + " is null!");
            return;            
        }            

        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
