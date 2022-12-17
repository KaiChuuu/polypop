using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet Setting")]
public class BulletSettings : ScriptableObject
{
    [Tooltip("Damage must be negative to actually 'inflict' damage!")]
    public int damage;

    public float bulletSpeed;

    public float bulletLifetime;
}
