using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    private Transform tf;
    public Transform TF
    {
        get
        {
            //tf = tf ?? gameObject.tranform;
            if (tf == null)
            {
                tf = transform;
            }
            return tf;
        }
    }

    public WeaponType poolType;
}
