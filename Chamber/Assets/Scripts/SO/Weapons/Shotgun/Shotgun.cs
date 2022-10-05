using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IWeaponTemplate
{
    public float shotgunSpread = 7f;

    public void fireWeapon(GameObject bullet, Transform player, Vector3 mousePosition3D)
    {
        GameObject go1 = Instantiate<GameObject>(bullet);
        GameObject go2 = Instantiate<GameObject>(bullet);
        GameObject go3 = Instantiate<GameObject>(bullet);

        go1.transform.position = player.position;
        go2.transform.position = player.position;
        go3.transform.position = player.position;

        go1.transform.LookAt(mousePosition3D);
        go2.transform.LookAt(mousePosition3D);
        go3.transform.LookAt(mousePosition3D);
        go2.transform.Rotate(new Vector3(0, 1, 0), shotgunSpread);
        go3.transform.Rotate(new Vector3(0, 1, 0), -shotgunSpread);

        Physics.IgnoreCollision(go1.GetComponent<SphereCollider>(), player.GetComponent<CapsuleCollider>());
        Physics.IgnoreCollision(go2.GetComponent<SphereCollider>(), player.GetComponent<CapsuleCollider>());
        Physics.IgnoreCollision(go3.GetComponent<SphereCollider>(), player.GetComponent<CapsuleCollider>());
    }
}
