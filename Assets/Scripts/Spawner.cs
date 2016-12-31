using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Spawner : MonoBehaviour
{

    public GameObject[] MyGameObjects;
    public float SpawnersToDivideBy;

    // Update is called once per frame
    void Update()
    {
        foreach (var myGameObject in MyGameObjects)
        {
            if (isTimeToSpawn(myGameObject))
            {
                Spawn(myGameObject);
            }
        }
    }

    public void Spawn(GameObject myGameObject)
    {
        var newGameObj = Instantiate(myGameObject, transform) as GameObject;
        newGameObj.transform.position = transform.position;
        //	Debug.Log ("Spawned " + newAttacker.name);
    }

    bool isTimeToSpawn(GameObject myGameObject)
    {
        var gameObj = myGameObject.GetComponent<Spawnable>();

        float meanSpawnDelay = gameObj.SeenEverySeconds;
        float spawnsperSecond = 1 / meanSpawnDelay;

        //if it took longer than the rate to render the frame then you can't 
        //spawn enemy
        if (Time.deltaTime > meanSpawnDelay)
            Debug.LogWarning("Spawn rate capped by frame rate");

        //Threshold is actually the probability to spawn this particular frame. 
        //Threshold is always beween 0 and 1
        //we are dividing by 5 in this case because we have 5 
        //spawners running at the same time				
        float threshold = spawnsperSecond * Time.deltaTime / SpawnersToDivideBy;

        //give me a number between 0 and 1 and if it's less than threshold spawn. 
        //random.value is < .20, 20% of the time and < .5 50% of the time.
        return (Random.value < threshold);
    }
}
