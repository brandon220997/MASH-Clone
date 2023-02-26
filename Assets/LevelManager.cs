using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelUI levelUI;

    // Start is called before the first frame update
    void Start()
    {
        levelUI.updateSoldierInHelicopter(0);
        levelUI.updateSoldiersRescued(0);
    }
}
