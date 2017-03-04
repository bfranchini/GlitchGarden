using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Spawner : MonoBehaviour
{
    public GameObject[] MyGameObjects;
    public float SpawnersToDivideBy;
    public static int MaxEnemiesOnFiled = 5;

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
        Debug.LogWarning("Now spawning " + myGameObject.name + ": " + Time.timeSinceLevelLoad);
        var newGameObj = Instantiate(myGameObject, transform);
       

        //if we're spawning a star then make it spin.       
        if (newGameObj.GetComponent<Star>())
        {
            //put stars in front of everything so they're always clickable
            var starPos = new Vector3(transform.position.x, transform.position.y, -2f);
            newGameObj.transform.position = starPos;
            newGameObj.GetComponent<Animator>().SetBool("IsSpinning", true);
            return;
        }

        newGameObj.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject myGameObject)
    {
        var attackerCount = GameObject.FindObjectsOfType<Attacker>().Length;        

        //Throttle the number of enemies so we don't overwhelm the player.
        if (attackerCount >= MaxEnemiesOnFiled)
            return false;

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
        var threshold = spawnsperSecond * Time.deltaTime / SpawnersToDivideBy;

        //give me a number between 0 and 1 and if it's less than threshold spawn. 
        //random.value is < .20, 20% of the time and < .5 50% of the time.
        return (Random.value < threshold);
    }
}
