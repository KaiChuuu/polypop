using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletTemplate
{
    public void DestroyMe();

    public void FireBullet();

    //Getter & Setters
    public void SetBulletDamage(int Damage);

    public int GetBulletDamage();
}
