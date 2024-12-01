using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/WeaponSO", order = 1)]

public class WeaponSO : ScriptableObject
{
    public List<GameObject> weapons;

    public GameObject GetGameObject(WeaponType weaponType)
    {
        return weapons[(int) weaponType];
    }
    
}

public enum WeaponType
{
    Arrow = 0,
    RedAxe = 1,
    BlueAxe = 2,
    Boomerang = 3,
    YellowCandy = 4,
    RedCandy = 5,
    OrangeCandy = 6,
    IceCream = 7,
    Hammer = 8,
    Knife = 9,
    Uzi = 10,
    Zee = 11,
    None = 12
}



