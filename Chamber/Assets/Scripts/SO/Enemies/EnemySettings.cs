using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Setting")]
public class EnemySettings : ScriptableObject
{
    public GameObject enemyModel;

    public int health;

    public float speed;

    public string enemyName;
}
