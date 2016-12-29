using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

public GameObject[] AttackerPrefabArray;
	
	// Update is called once per frame
	void Update () 
	{
		foreach(var attacker in AttackerPrefabArray)
		{
			if(isTimeToSpawn(attacker))
			{
				Spawn(attacker);		
			}
		}		
	}
	
	public void Spawn(GameObject myGameObject)
	{
		var newAttacker = Instantiate(myGameObject) as GameObject;
		newAttacker.transform.parent = transform;
		newAttacker.transform.position = transform.position;
	//	Debug.Log ("Spawned " + newAttacker.name);
	}
	
	bool isTimeToSpawn(GameObject myAttacker)
	{
		var attacker = myAttacker.GetComponent<Attacker>();
		
		float meanSpawnDelay = attacker.SeenEverySeconds;
		float spawnsperSecond = 1 / meanSpawnDelay;
		
		//if it took longer than the rate to render the frame then you can't 
		//spawn enemy
		if(Time.deltaTime > meanSpawnDelay)		
			Debug.LogWarning("Spawn rate capped by frame rate");
				
		//Threshold is actually the probability to spawn this particular frame. 
		//Threshold is always beween 0 and 1
		//we are dividing by 5 in this case because we have 5 
		//spawners running at the same time				
		float threshold = spawnsperSecond * Time.deltaTime / 5;
		
		//give me a number between 0 and 1 and if it's less than threshold spawn. 
		//random.value is < .20, 20% of the time and < .5 50% of the time.
		return(Random.value < threshold);
	}
}
