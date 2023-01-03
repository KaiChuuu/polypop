using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeaponTemplate
{
    public void fireWeapon(GameObject bullet, Transform player, Vector3 mousePosition3D)
    {
        GameObject bullet1 = Instantiate<GameObject>(bullet);
        bullet1.transform.position = player.position;
        bullet1.transform.LookAt(mousePosition3D);

        bullet1.GetComponent<IBulletTemplate>().FireBullet();
    }
}