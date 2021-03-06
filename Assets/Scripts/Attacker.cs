﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	private float currentSpeed;
    private AudioSource audioSource;
    private GameObject currentTarget;
	private Animator animator;
    private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () 
	{		
		animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	    particleSystem = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if(!currentTarget)
		{			
			animator.SetBool("IsAttacking", false);
		}				
	}	
	
	//set speed of attacker transform so it moves
	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}
	
	//called from the animator at time of blow
	public void StrikeCurrentTarget(float damage)
	{
		if(currentTarget)
		{
			var health = currentTarget.GetComponent<Health>();
			
			if(health)
			    health.DealDamage(damage);

		    if (particleSystem && !particleSystem.isEmitting)
		    {
                particleSystem.Play();
            }              
		}
	}
	
	public void Attack(GameObject obj)
	{
		currentTarget = obj;	
	}

    public void PlayChewingSound()
    {
        audioSource.Play();
    }
}

