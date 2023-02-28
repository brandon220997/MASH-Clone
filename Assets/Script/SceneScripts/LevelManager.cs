using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject SoldierPrefab;
    public GameObject TreePrefab;

    public LevelUI levelUI;

    public bool Procedural = false;

    private List<Vector2> BlockOrigins= new List<Vector2>
    {
        new Vector2(0f,10f),
        new Vector2(0f,0f),
        new Vector2(0f,-10f),
        new Vector2(-10f,-10f),
        new Vector2(-20f,-10f),
        new Vector2(-20f,0f),
        new Vector2(-20f,10f),
        new Vector2(-10f,10f),
    };

    void Awake()
    {
        if (Procedural) GenerateLevel();
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
            // Restart Game
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if(GameManager.levelService.GetLevelState() == LevelState.LevelStop)
        {
            // New Game
            if (Input.GetKeyUp(KeyCode.R))
            {
                if (GameManager.levelService.GameIsWon())
                {
                    GameManager.levelGeneratorService.NewLevelSchema(BlockOrigins);
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            // Exit
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }

    private void GenerateLevel()
    {
        var levelSchema = GameManager.levelGeneratorService.GetLevelSchema(BlockOrigins);

        levelSchema.ForEach(x =>
        {
            if (x.spawnType == SpawnType.Soldier)
            {
                Instantiate(SoldierPrefab, x.spawnPoint, Quaternion.identity);
            }
            else if (x.spawnType == SpawnType.Tree)
            {
                Instantiate(TreePrefab, x.spawnPoint, Quaternion.identity);
            }
        });
    }
}
