using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static private Transform _ENEMY_ANCHOR;

    static Transform ENEMY_ANCHOR
    {
        get
        {
            if(_ENEMY_ANCHOR == null)
            {
                GameObject go = new GameObject("EnemyAnchor");
                _ENEMY_ANCHOR = go.transform;
            }
            return _ENEMY_ANCHOR;
        }
    }

    public float speed = 2.0f;
    private GameObject player;
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            collision.gameObject.GetComponent<Player>().disablePlayer();

            //Stop spawner from spawning




            //Maybe dont stop time
            //Time.timeScale = 0;
            
        }
    }
}
