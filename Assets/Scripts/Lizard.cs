using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;
	
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
		
		if(obj.GetComponent<Defender>())
		{
			animator.SetBool("IsAttacking", true);
			attacker.Attack(obj);
		}
	}
}
