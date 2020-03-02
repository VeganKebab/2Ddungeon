using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float destroyDistance;
    
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance){
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) == destroyDistance){
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Destroy(gameObject);
            ScoreScript.score += 1;
        }
    }
}
