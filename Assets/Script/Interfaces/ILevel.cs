using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    void InitializeGame();
    LevelState GetLevelState();
    void PickupSoldier(GameObject soldier);
    void DropSoldier();
    int GetSoldiersInHeliCount();
    int GetSoldiersRescuedCount();
    bool GameIsWon();
    void StopGame();
}
