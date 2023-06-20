using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    [SerializeField] [Tooltip("this is a bool checking if you can place a defense tower here")] private bool is_Placable;
    public bool Is_Placable { get { return Is_Placable; } } //this method will return the bool
    
    [SerializeField][Tooltip("this is the defense tower")] private Tower tower;

    
   
    private void OnMouseDown()
    {
        if (is_Placable)
        {
            bool is_Placed = tower.Create_Tower(tower, transform.position);

            is_Placable = !is_Placed;
        }
        
    }
}
