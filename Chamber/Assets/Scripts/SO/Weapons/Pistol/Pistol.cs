using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeaponTemplate
{
    public void fireWeapon(GameObject bullet, Transform player, Vector3 mousePosition3D)
    {
        GameObject go = Instantiate<GameObject>(bullet);
        go.transform.position = player.position;
        go.transform.LookAt(mousePosition3D);

        Physics.IgnoreCollision(go.GetComponent<SphereCollider>(), player.GetComponent<CapsuleCollider>());
    }
}
