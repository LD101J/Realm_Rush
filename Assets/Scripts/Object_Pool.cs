using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pool : MonoBehaviour
{
    [SerializeField] private GameObject enemy_Prefab;
    [SerializeField][Range(0,50)] private int pool_Size = 5;
     private GameObject[] pool;
    [SerializeField][Range(0.1f, 20)] private float spawn_Timer = 1f;

    private void Awake()
    {
        Populate_Pool();
    }

    private void Populate_Pool()
    {
        pool = new GameObject[pool_Size];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy_Prefab, transform);
            pool[i].SetActive(false);
        } 
    }

    private void Start()
    {
        StartCoroutine(Spawn_Enemy());
       //Enable_Objects_In_Pool();
    }

    private void Enable_Objects_In_Pool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    private IEnumerator Spawn_Enemy()
    {
        while (true)
        {
            Enable_Objects_In_Pool();
            yield return new WaitForSeconds(spawn_Timer);
        }
    }
}
