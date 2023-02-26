using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelUI levelUI;

    void Awake()
    {
        GameManager.StartLevel();
    }

    void Start()
    {
        levelUI.updateSoldierInHelicopter(0);
        levelUI.updateSoldiersRescued(0);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && GameManager.levelService.GetLevelState() == LevelState.LevelStop)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && GameManager.levelService.GetLevelState() == LevelState.LevelStop)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
