using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

// Tree: Tree Overlap 4, Soldier Overlap 2
// Soldier: Tree Overlap 2, Soldier Overlap 2
public enum SpawnType
{
    Soldier,
    Tree,
}

public class LevelGeneratorService : ILevelGeneratorService
{
    private float[,] spawnRanges = { { 1.5f , 2f },
                                     { 2f , 3.3f } };

    private int spawnTries = 50;
    private int maxSoldiers = 3;

    private List<(SpawnType spawnType, Vector2 spawnPoint)> levelSchema;

    public void NewLevelSchema(List<Vector2> blockOrigins)
    {
        levelSchema = new List<(SpawnType spawnType, Vector2 spawnPoint)>();
        blockOrigins.ForEach(bo =>
        {
            levelSchema.AddRange(spawnWithinSquare(bo, 10f, 10f));
        });
    }

    List<(SpawnType spawnType, Vector2 spawnPoint)> ILevelGeneratorService.GetLevelSchema(List<Vector2> blockOrigins)
    {
        if (levelSchema == null)
        {
            NewLevelSchema(blockOrigins);
            return levelSchema;
        }

        return levelSchema;
    }

    private List<(SpawnType spawnType, Vector2 spawnPoint)> spawnWithinSquare(Vector2 pointOfOrigin, float xWidth, float yLength)
    {
        var objectsWithinArea = new List<(SpawnType spawnType, Vector2 spawnPoint)>();
        var blockMaxSoldier = Random.Range(1, maxSoldiers);
        int currentSoldierCount = 0;

        for (int spawns = 0; spawns < spawnTries; spawns++)
        {
            Vector2 randomPoint = new Vector2(Random.Range(pointOfOrigin.x + 1f, pointOfOrigin.x + xWidth - 1f), Random.Range(pointOfOrigin.y + 1f, pointOfOrigin.y + yLength - 1f));

            var spawnValue = RandomSpawnValue();
            if (!levelSchema.Where(x => x.spawnType == SpawnType.Soldier).Any())
            {
                spawnValue = SpawnType.Soldier;
            }

            if (currentSoldierCount >= blockMaxSoldier) spawnValue = SpawnType.Tree;

            if (!HasOverlap(objectsWithinArea, randomPoint, spawnValue))
            {
                objectsWithinArea.Add((spawnValue, randomPoint));
                if (spawnValue == SpawnType.Soldier) currentSoldierCount++;
            }
        }

        return objectsWithinArea;
    }

    private SpawnType RandomSpawnValue()
    {
        var values = System.Enum.GetValues(typeof(SpawnType));
        return (SpawnType)values.GetValue(Random.Range(0, 2));
    }

    private bool HasOverlap(List<(SpawnType spawnType, Vector2 spawnPoint)> objectsWithinArea, Vector2 point, SpawnType spawnType)
    {
        bool overlap = false;

        objectsWithinArea.ForEach(x =>
        {
            if (Vector2.Distance(x.spawnPoint, point) < spawnRanges[(int)x.spawnType, (int)spawnType])
            {
                overlap = true;
            }
        });

        return overlap;
    }
}
