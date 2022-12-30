using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Setting")]
public class WeaponSettings : ScriptableObject
{
    //weaponModel contains unqiue script for unique gun
    public GameObject weaponModel;

    public GameObject bulletType;

    public string weaponName;

    public GameObject weaponShopModel;
}
