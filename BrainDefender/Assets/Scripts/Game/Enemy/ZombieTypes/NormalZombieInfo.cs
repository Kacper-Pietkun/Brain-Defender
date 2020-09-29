using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombieInfo : ZombieInfo
{
    public NormalZombieInfo(int spawnRoundNumber)
        : base(spawnRoundNumber)
    {
        MaxHealtPoints = 3;
        MovementSpeed = 2;
        AttackDamage = 3;
        Weight = 8;
        MinimalDistance = 1.5f;
    }
}

