using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInfo
{
    // Information for Waves Manager
    public int SpawnRoundNumber { get; set; }

    // Zombie Statistics
    public int MaxHealtPoints { get; set; }
    public float MovementSpeed { get; set; }
    public int AttackDamage { get; set; }
    public float Weight { get; set; }
    public float MinimalDistance { get; set; }

    public ZombieInfo(int spawnRoundNumber)
    {
        SpawnRoundNumber = spawnRoundNumber;
    }
}
