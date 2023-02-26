using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameEndText;
    [SerializeField] private GameObject gameEndScreen;

    [SerializeField] private TextMeshProUGUI soldierInHelicopter;
    [SerializeField] private TextMeshProUGUI soldiersRescued;

    public void updateSoldierInHelicopter(int count)
    {
        soldierInHelicopter.text = $"Soldiers In Helicopter: {count}";
    }

    public void updateSoldiersRescued(int count)
    {
        soldiersRescued.text = $"Soldiers Rescued: {count}";
    }

    public void displayGameEndScreen(bool gameIsWon)
    {
        if (gameIsWon)
        {
            gameEndText.text = "You Won!";
        }
        else
        {
            gameEndText.text = "Game Over!";
        }

        gameEndScreen.SetActive(true);
    }
}
