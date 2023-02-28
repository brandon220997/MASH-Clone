using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelUI levelUI;

    void Awake()
    {
        GameManager.instance.StartLevel();
    }

    void Start()
    {
        levelUI.updateSoldierInHelicopter(0);
        levelUI.updateSoldiersRescued(0);
    }

    private void Update()
    {
        if(GameManager.levelService.GetLevelState() == LevelState.LevelStart)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if(GameManager.levelService.GetLevelState() == LevelState.LevelStop)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }
}
