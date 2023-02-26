using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum LevelState
{
    LevelStart,
    LevelStop,
}

public class LevelManagerService : ILevelManager
{
    public LevelState levelState;

    private int currentSoldierPickup;
    private int maxSoldierCapacity = 3;

    private List<Transform> soldiers;
    private int soldiersRescued = 0;

    void ILevelManager.InitializeGame()
    {
        soldiers = GameObject.FindGameObjectsWithTag("Soldier").Select(go => go.transform).ToList();
        levelState = LevelState.LevelStart;
    }

    LevelState ILevelManager.GetLevelState()
    {
        return levelState;
    }

    void ILevelManager.PickupSoldier(GameObject soldier)
    {
        if(currentSoldierPickup < maxSoldierCapacity)
        {
            currentSoldierPickup++;
            soldier.SetActive(false);
        }
    }

    void ILevelManager.DropSoldier()
    {
        soldiersRescued += currentSoldierPickup;
        currentSoldierPickup = 0;

        if (soldiersRescued == soldiers.Count()) Debug.Log("You Won!");
    }

    bool ILevelManager.GameIsWon()
    {
        return soldiersRescued == soldiers.Count();
    }

    void ILevelManager.StopGame()
    {
        levelState = LevelState.LevelStop;
    }
}
