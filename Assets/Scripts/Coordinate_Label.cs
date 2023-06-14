using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways] ///these makes it execute in edit mode * play mode
public class Coordinate_Label : MonoBehaviour
{
    private TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();//accessing the textmeshpro component
        Display_Current_Coordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            Display_Current_Coordinates();
            Update_Cube_Name();
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
