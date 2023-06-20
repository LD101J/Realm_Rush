using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int money_Reward = 25;
    [SerializeField] private int money_Penalty = 25;

    private Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    public void Reward_Money()
    {
        if(bank == null)
        {
            return;
        }
        bank.Deposit(money_Reward);
    }
    public void Money_Taken()
    {
        if (bank == null)
        {
            return;
        }
        bank.Withdraw(money_Penalty);
    }
}
