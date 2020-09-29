using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketZombieInfo : ZombieInfo
{
    public BucketZombieInfo(int spawnRoundNumber)
        : base(spawnRoundNumber)
    {
        MaxHealtPoints = 5;
        MovementSpeed = 1.8f;
        AttackDamage = 3;
        Weight = 8.5f;
        MinimalDistance = 1.5f;
    }
}