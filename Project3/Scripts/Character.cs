using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Character : PlayerController
{
    [SerializeField] public float radius = 1;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] Transform weaponParent;
    [SerializeField] float throwForce;
    [SerializeField] Transform weaponSpawnLocation;
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] float scaleFactor = 1f;
    [SerializeField] float maxScale = 20f;
    Collider[] hitColliders = new Collider[20];

    int enemyCount;
    protected Vector3 targetEnemy;
    internal float currentTime = 0;
    public float attackCooldown = 2f;
    public float range = 10f;
    private float lastAttackTime = -Mathf.Infinity;
    private Collider humanCollider;
    public float torque;

    private void Update()
    {
        FindTarget(transform.position, radius);
        if (targetEnemy != null && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            ChangeAnim(Constant.AttackAnimName);
            lastAttackTime = Time.time;
        }
    }

    //xoay vu khi
    //Quaternion targetRotation = Quaternion.Euler(0, 180, 0);

    public void FindTarget(Vector3 position, float radius)
    {
        enemyCount = Physics.OverlapSphereNonAlloc(position, radius, hitColliders, enemyLayer);
        float minDistance = Mathf.Infinity;
        Collider nearestEnemy = null;

        for (int i = 0; i < enemyCount; i++)
        {
            float distance = Vector3.Distance(position, hitColliders[i].transform.position);   
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = hitColliders[i];
            }
            if (nearestEnemy != null)
            {
                targetEnemy = nearestEnemy.transform.position;  
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        for (int i = 0; i < enemyCount; i++)
        {
            Gizmos.DrawLine(transform.position, hitColliders[i].transform.position);
        }
    }

    public void Attack()
    {
        GameObject throwWeapon = Instantiate(weaponPrefab, weaponSpawnLocation.position, Quaternion.Euler(90, 0, 0), weaponParent);

        Rigidbody rb = throwWeapon.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (targetEnemy != Vector3.zero)
            {
                Vector3 direction = targetEnemy - transform.position;   
                Debug.Log("ke dich" + targetEnemy);
                rb.AddForce(direction * throwForce, ForceMode.Impulse);

                Vector3 torqueDirection = Vector3.up * torque;
                rb.AddTorque(torqueDirection, ForceMode.Impulse);
            }
        }
    }

    protected void Death()
    {
        humanCollider = GetComponent<Collider>();

        if (humanCollider != null)
        {
            humanCollider.enabled = false;                  
        }
        else
        {
            Debug.Log("unknow collider");
        }
        //chet
        Destroy(gameObject);    
        Debug.Log("Player is death");
    }

    protected void UpScale()
    {
        if (transform.localScale.x < maxScale)
        {
            transform.localScale *= scaleFactor;
        }
    }
}
