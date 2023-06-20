using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Seeker : MonoBehaviour
{
    [SerializeField][Tooltip("this is the weopon head")] private Transform weapon_Head;
     [Tooltip("this is the enemy target")] private Transform weapon_Target;
    [SerializeField] private float tower_Range = 15f;
    [SerializeField] private ParticleSystem arrow;
    
    private void Update()
    {
        Find_Nearest_Target();
        Aim_Weapon_Head();
    }

    private void Find_Nearest_Target()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();//look through the enemy array
        Transform closestTarget = null;//this is the tranform that is used to find the closest enemy 
        float maxDistance = Mathf.Infinity; 
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        weapon_Target = closestTarget;
    }

    private void Aim_Weapon_Head()
    {
        float targetDistance = Vector3.Distance(transform.position, weapon_Target.position);

        weapon_Head.LookAt(weapon_Target);
        if(targetDistance < tower_Range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    private void Attack(bool is_Active)
    {
        var emmision = arrow.emission;
        emmision.enabled = is_Active;
    }
}
