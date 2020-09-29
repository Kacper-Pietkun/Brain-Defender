using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesList : MonoBehaviour
{
    public List<WaveInfo> waves = new List<WaveInfo>();

    private void Awake()
    {
        waves.Add(new WaveInfo(roundsNumber: 5, spawnRoundInterval: 6f, zombies: new List<ZombieInfo>()
        {
            new NormalZombieInfo(3)
        }));

        waves.Add(new WaveInfo(roundsNumber: 5, spawnRoundInterval: 6f, zombies: new List<ZombieInfo>()
        {
            new BucketZombieInfo(4)
        }));

        waves.Add(new WaveInfo(roundsNumber: 5, spawnRoundInterval: 6f, zombies: new List<ZombieInfo>()
        {
            new NormalZombieInfo(3),
            new BucketZombieInfo(3),
        }));
    }
}
