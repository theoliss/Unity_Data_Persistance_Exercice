using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using TMPro;

public class Main_Menu_Buttons : MonoBehaviour
{

    public string playerName;

    [SerializeField] private TMP_InputField inputTextBox;

    [SerializeField] private GameManager gameManager;

    public void Quit_Button()
    {
        gameManager.Quit_Game();
    }

    public void Start_Button()
    {
        string playerName = inputTextBox.text;
        Debug.Log("The player's name is : " + playerName);
        if(!string.IsNullOrWhiteSpace(playerName))
        {
            gameManager.playerName = playerName;
            gameManager.Start_Game();
        }
        else
        {
            Debug.Log("Can't start without a beautifful name to display");
        }
    }

    public void Load_High_Scores_Button()
    {
        //work in progress
    }

    public void Reset_High_Scores_Button()
    {
        gameManager.Reset_High_Scores();
    }

}
