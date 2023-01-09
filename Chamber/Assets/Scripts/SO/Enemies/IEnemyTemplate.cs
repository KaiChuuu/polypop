using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTemplate
{
    public void MoveTowardPlayer();

    public void SetEnemyStats(int gameDifficulty, float enemySpeed, int enemyHealth);
}
