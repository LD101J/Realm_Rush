using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]// this enemy class has to come with
public class Enemy_Health : MonoBehaviour
{
    #region Variables
    [SerializeField] private int maxHitPoints = 5;
    [Tooltip("adds 1 health to the enemy everytime they die")][SerializeField] private int health_Boost = 1;
     private int currentHitPoints = 0;
    private Enemy enemy;
    #endregion

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        Process_Hit();
       
    }

    private void Process_Hit()
    {
        currentHitPoints--;
        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            enemy.Reward_Money();
            maxHitPoints += health_Boost;
        }
    }
}
