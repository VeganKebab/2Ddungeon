using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
	public GameObject enemy;

	public GameObject[] spawnPoints;

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
		    int rand = Random.Range(0, spawnPoints.Length);
			whereToSpawn = new Vector2(spawnPoints[rand].transform.position.x
			, spawnPoints[rand].transform.position.y);
		    Instantiate(enemy, whereToSpawn, Quaternion.identity);
		    spawned++;
	    }
    }
}
