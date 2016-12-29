using UnityEngine;
using System.Collections;

//This causes Unity to check to make sure any Fox instances have an Attacker component
//attached to it
[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour 
{
	Attacker attacker;
	Animator animator; 
	
	// Use this for initialization
	void Start () 
	{
		attacker = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{	
		var obj = coll.gameObject;
		
		//Leave method if not colliding with defender
		if(!obj.GetComponent<Defender>())
		{		
			return;
		}
		
		if(obj.GetComponent<Stone>())
		{
			animator.SetTrigger("JumpTrigger");			
		}
		else
		{
			animator.SetBool("IsAttacking", true);
			attacker.Attack(obj);			
		}	
	}	
}
