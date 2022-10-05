using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponTemplate
{
    public void fireWeapon(GameObject bullet, Transform player, Vector3 mousePosition3D);
}
