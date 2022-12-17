using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTemplate
{
    public void MoveTowardPlayer();

    public void SetEnemySpeed(float speed);

    public void SetEnemyHealth(int health);
}
