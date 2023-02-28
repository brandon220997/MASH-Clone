using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelGeneratorService
{
    void NewLevelSchema(List<Vector2> blockOrigins);
    List<(SpawnType spawnType, Vector2 spawnPoint)> GetLevelSchema(List<Vector2> blockOrigins);
}
