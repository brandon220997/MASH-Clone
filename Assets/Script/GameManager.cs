using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentSoldierPickup;
    private int maxSoldierCapacity = 3;

    public List<Transform> soldiers;
    private int soldiersRescued = 0;


    // Start is called before the first frame update
    void Start()
    {
        soldiers = GameObject.FindGameObjectsWithTag("Soldier").Select(go => go.transform).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
