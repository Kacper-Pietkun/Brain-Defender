using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveInfo
{
    public int RoundsNumber { get; set; }
    public float SpawnRoundInterval { get; set; }

    public List<ZombieInfo> Zombies = new List<ZombieInfo>();

    public WaveInfo(int roundsNumber, float spawnRoundInterval, List<ZombieInfo> zombies)
    {
        RoundsNumber = roundsNumber;
        SpawnRoundInterval = spawnRoundInterval;
        Zombies = zombies;
    }

    public int GetNumberOfAllZombies()
    {
        int numberOfAllZombies = 0;
        foreach (ZombieInfo info in Zombies)
        {
            numberOfAllZombies += info.SpawnRoundNumber * RoundsNumber;
        }
        return numberOfAllZombies;
    }
}
