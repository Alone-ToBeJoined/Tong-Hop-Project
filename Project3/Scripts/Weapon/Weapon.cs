using System;
using System.Net.Security;
using UnityEngine;


public class Weapon : GameUnit
{
    private Character character;
    [SerializeField] float attacForce;
    [SerializeField] private Bullet bulletPrefab;

    public void Throw(Character character, Action<Character, Character > onHit)
    {
        //Vector3 shooDirection = (character.targetEnemy - transform.position);
        //Bullet bullet = 
    }
}
