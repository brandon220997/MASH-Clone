using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelService
{
    void InitializeGame();
    LevelState GetLevelState();
    bool PickupSoldier(GameObject soldier);
    bool DropSoldier();
    int GetSoldiersInHeliCount();
    int GetSoldiersRescuedCount();
    bool GameIsWon();
    void StopGame();
}
