using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;// tower cost
    public bool Create_Tower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }
        if(bank.Current_Money >= cost)
        {
        Instantiate(tower, position, Quaternion.identity);
        bank.Withdraw(cost);
        return true;
        }
        return false;
    }
}
