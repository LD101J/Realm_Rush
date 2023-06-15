using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] private float timeToWait;
    private void Start()
    {
       StartCoroutine(Waypoint_Name());//calling a coroutine   
    }

    private IEnumerator Waypoint_Name()//this is a coroutine. due to return type
    {
        foreach(Waypoint waypoint in path)
        {
            gameObject.transform.position = waypoint.transform.position; 
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
