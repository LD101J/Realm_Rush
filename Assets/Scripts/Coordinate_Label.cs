using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways] ///these makes it execute in edit mode & play mode
[RequireComponent(typeof(TextMeshPro))]
public class Coordinate_Label : MonoBehaviour
{
    #region Variables
    private TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    //colour change
     private Waypoint waypoint;
    [SerializeField] private Color is_Placeable = Color.green;
    [SerializeField] private Color is_Not_Placeable = Color.red;
    #endregion
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();//accessing the textmeshpro component
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        Display_Current_Coordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            Display_Current_Coordinates();
            Update_Cube_Name();
            label.enabled = true;
        }
         Toggle_Labels();
        //Set_Label_Colour();
    }
    private void Toggle_Labels()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void Set_Label_Colour()
    {
        if (waypoint.Is_Placable)
        {
            label.color = is_Placeable;
        }
        else
        {
            label.color = is_Not_Placeable;
        }
    }

    private void Update_Cube_Name()
    {
        transform.parent.name = coordinates.ToString();
    }

    private void Display_Current_Coordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }
}
