using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
	public GameObject enemy;

	private float randX;
	private float randY;

	private Vector2 whereToSpawn;

	public float spawnRate = 2f;

	private float nextSpawn = 0.0f;

	public float spawnNumber = 2f;

	private float spawned = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Time.time > nextSpawn && spawned < spawnNumber)
	    {
		    nextSpawn = Time.time + spawnRate;
		    randX = Random.Range(-7.5f, 7.5f);
		    randY = Random.Range(-3.5f, 3.5f);
		    whereToSpawn = new Vector2(randX, randY);
		    Instantiate(enemy, whereToSpawn, Quaternion.identity);
		    spawned++;
	    }
    }
}
