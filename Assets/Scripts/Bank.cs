using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Bank : MonoBehaviour
{
    [SerializeField] private int starting_Money = 150;
    [SerializeField] private int current_Money;
    [SerializeField] private TextMeshProUGUI moneyUI;
    public int Current_Money { get { return current_Money; } }

    private void Awake()
    {
        current_Money = starting_Money;
        Update_UI();
    }
    public void Deposit(int amount)
    {
        current_Money +=Mathf.Abs(amount);
        Update_UI();
    }
    public void Withdraw(int amount)
    {
        current_Money -= Mathf.Abs(amount);
        Update_UI();
       
        if(current_Money < 0)
        {
            Reload_Scene();
        }
    }

    private void Reload_Scene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    private void Update_UI()
    {
        moneyUI.text = "Cash" + current_Money;
    }
}
