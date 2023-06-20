using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Enemy_Mover : MonoBehaviour
{
    [SerializeField][Tooltip("this is the waypoint path")] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f,5f)][Tooltip("speed of enemies")] private float moveSpeed;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
       Find_Path();
       Return_Start();
       StartCoroutine(Waypoint_Name());//calling a coroutine   
    }

    private void Return_Start()
    {
        transform.position = path[0].transform.position;
    }

    private void Find_Path()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);
            }
            
        }
    }
    private void Finish_Path()
    {
        gameObject.SetActive(false);
        enemy.Money_Taken();
    }
    private IEnumerator Waypoint_Name()//this is a coroutine. due to return type
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPos);//always look at where it is going

            while(travelPercent < 1)//when its not at the end   
            {
                travelPercent += Time.deltaTime * moveSpeed;//this will move the enemy smoothly
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        Finish_Path();
    }
}
