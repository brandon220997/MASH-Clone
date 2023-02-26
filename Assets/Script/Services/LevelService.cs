using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum LevelState
{
    LevelStart,
    LevelStop,
}

public class LevelService : ILevel
{
    public LevelState levelState;

    private int currentSoldierPickup;
    private int maxSoldierCapacity = 3;

    private List<Transform> soldiers;
    private int soldiersRescued = 0;

    void ILevel.InitializeGame()
    {
        soldiers = GameObject.FindGameObjectsWithTag("Soldier").Select(go => go.transform).ToList();
        levelState = LevelState.LevelStart;
    }

    LevelState ILevel.GetLevelState()
    {
        return levelState;
    }

    void ILevel.PickupSoldier(GameObject soldier)
    {
        if(currentSoldierPickup < maxSoldierCapacity)
        {
            currentSoldierPickup++;
            soldier.SetActive(false);
        }
    }

    void ILevel.DropSoldier()
    {
        soldiersRescued += currentSoldierPickup;
        currentSoldierPickup = 0;
    }

    bool ILevel.GameIsWon()
    {
        return soldiersRescued == soldiers.Count();
    }

    void ILevel.StopGame()
    {
        levelState = LevelState.LevelStop;
    }

    int ILevel.GetSoldiersInHeliCount()
    {
        return currentSoldierPickup;
    }

    int ILevel.GetSoldiersRescuedCount()
    {
        return soldiersRescued;
    }
}
