using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Services
    public static ILevelService levelService;
    public static IAudioService audioService;

    // Collections
    public AudioCollection audioCollection;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioService = new AudioService(audioCollection);
    }

    public void StartLevel()
    {

        levelService = new LevelService();
        levelService.InitializeGame();
    }
}
