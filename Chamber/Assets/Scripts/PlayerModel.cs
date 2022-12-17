using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class PlayerModel : MonoBehaviour
{
    //I wanted the collision detection to be layered as a child of the mesh itself,
    //rather than in the Player gameObject.

    public GameObject player;

    public void DamagePlayer()
    {
        player.GetComponent<Player>().DamagePlayer();
    }
}
