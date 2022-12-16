using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Setting")]
public class EnemySettings : ScriptableObject
{
    GameObject enemyModel;

    public int health;

    public float speed;
}
