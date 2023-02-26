using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelManager
{
    void InitializeGame();
    LevelState GetLevelState();
    void PickupSoldier(GameObject soldier);
    void DropSoldier();
    bool GameIsWon();
    void StopGame();
}
