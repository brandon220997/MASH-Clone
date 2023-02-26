using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static ILevel level;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartLevel()
    {

        level = new LevelService();
        level.InitializeGame();
    }
}
