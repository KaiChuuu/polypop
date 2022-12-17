using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeaponTemplate
{
    public float shotgunSpread = 7f;

    public void fireWeapon(GameObject bullet, Transform gun, Vector3 mousePosition3D)
    {
        GameObject bullet1 = Instantiate<GameObject>(bullet);
        GameObject bullet2 = Instantiate<GameObject>(bullet);
        GameObject bullet3 = Instantiate<GameObject>(bullet);

        bullet1.transform.position = gun.position;
        bullet2.transform.position = gun.position;
        bullet3.transform.position = gun.position;

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        bullet1.transform.LookAt(mousePosition3D);
        bullet2.transform.LookAt(mousePosition3D);
        bullet3.transform.LookAt(mousePosition3D);

        bullet1.GetComponent<IBulletTemplate>().FireBullet();
        
        bullet2.transform.Rotate(new Vector3(0,-1,0), shotgunSpread);
        bullet2.GetComponent<IBulletTemplate>().FireBullet();

        bullet3.transform.Rotate(new Vector3(0,-1,0), -shotgunSpread);
        bullet3.GetComponent<IBulletTemplate>().FireBullet();
    }
}
