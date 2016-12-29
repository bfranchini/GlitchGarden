using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour 
{
	private Animator animator;

	public void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void OnTriggerStay2D(Collider2D collider)
	{
		if(collider.GetComponent<Attacker>())
		{
			animator.SetTrigger("UnderAttackTrigger");
		}
	}	
}
