using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicEnemy : MonoBehaviour, IEnemyTemplate
{
    private float enemySpeed = 0.5f;
    private int enemyHealth = 2;

    private GameObject gameManager;
    private GameObject player;
    private NavMeshAgent enemyAgent;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardPlayer();
        checkSelfHealth();

        //Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //enemyRb.AddForce(lookDirection * speed);
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("hit something");
        if (collider.gameObject.tag == "PlayerModel")
        {
            collider.gameObject.GetComponent<PlayerModel>().DamagePlayer();
            Debug.Log("hit player");
        }
        else if (collider.gameObject.tag == "Bullet")
        {
            //Lose hp
            Debug.Log("hit enemy");
            UpdateHealth(collider.gameObject.GetComponent<IBulletTemplate>().GetBulletDamage());

            //Destroy bullet
            collider.gameObject.GetComponent<IBulletTemplate>().DestroyMe();
        }

    }

    void DestroyMe()
    {
        //Update total kill count
        gameManager.GetComponent<GameManager>().UpdateKillTotal();

        Destroy(gameObject.transform.parent.gameObject);

        //Death animation

        //If i wanted to add some unique death trait, it would be here.
    }

    void checkSelfHealth()
    {
        if(enemyHealth <= 0)
        {
            DestroyMe();
        }
    }

    void UpdateHealth(int damage)
    {
        enemyHealth += damage;
    }

    public void MoveTowardPlayer()
    {
        enemyAgent.destination = player.transform.position;
    }

    public void SetEnemyStats(float speed, int health)
    {
        enemySpeed = speed;
        enemyHealth = health;
    }
}
