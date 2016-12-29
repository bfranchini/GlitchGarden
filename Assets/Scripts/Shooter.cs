﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
	public GameObject Projectile, gun;	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner; 
	
	void Start()
	{		
		animator = GetComponent<Animator>();					
		
		//creates parent if necessary
		projectileParent = GameObject.Find("Projectiles");
		
		if(!projectileParent)
			projectileParent = new GameObject("Projectiles");
			
		setMyLaneSpawner();
		print (myLaneSpawner);
	}
	
	void Update()
	{
		if(isAttakerAheadInLane())
			animator.SetBool("IsAttacking", true);
		else
			animator.SetBool("IsAttacking", false);			
	}
	
	bool isAttakerAheadInLane()
	{	
		var attackers = myLaneSpawner.GetComponentsInChildren<Attacker>();
				
		foreach (var attacker in attackers)		
			if(attacker.transform.position.x > transform.position.x)
				return true;					
									
		//exit if no attackers in lane or if they're behind us	
		return false;
	}
	
	//look through all spawners, and set mylaneSpawner if found
	void setMyLaneSpawner()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner spawner in spawnerArray)
		{
			if(spawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawner;
				return;
			}					
		}
		
		Debug.LogError(name + " spawner not found for lane: " + gameObject.transform.position.y);			
	}
	
	
	private void Fire()
	{
		GameObject newProjectile = Instantiate(Projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
		
		//i originally did it like this. Bad! 
		//newProjectile.transform.position = transform.GetChild (1).transform.position;
	}

}
