using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum LevelState
{
    LevelStart,
    LevelStop,
}

public class LevelService : ILevelService
{
    public LevelState levelState;

    private int currentSoldierPickup;
    private int maxSoldierCapacity = 3;

    private List<Transform> soldiers;
    private int soldiersRescued = 0;

    void ILevelService.InitializeGame()
    {
        soldiers = GameObject.FindGameObjectsWithTag("Soldier").Select(go => go.transform).ToList();
        levelState = LevelState.LevelStart;
    }

    LevelState ILevelService.GetLevelState()
    {
        return levelState;
    }

    bool ILevelService.PickupSoldier(GameObject soldier)
    {
        if(currentSoldierPickup < maxSoldierCapacity)
        {
            currentSoldierPickup++;
            soldier.SetActive(false);

            return true;
        }

        return false;
    }

    bool ILevelService.DropSoldier()
    {
        if(currentSoldierPickup > 0)
        {
            soldiersRescued += currentSoldierPickup;
            currentSoldierPickup = 0;

            return true;
        }

        return false;
    }

    bool ILevelService.GameIsWon()
    {
        return soldiersRescued == soldiers.Count();
    }

    void ILevelService.StopGame()
    {
        levelState = LevelState.LevelStop;
    }

    int ILevelService.GetSoldiersInHeliCount()
    {
        return currentSoldierPickup;
    }

    int ILevelService.GetSoldiersRescuedCount()
    {
        return soldiersRescued;
    }
}
