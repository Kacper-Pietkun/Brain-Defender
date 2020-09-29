using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistics : MonoBehaviour
{
    public int MaxHealtPoints { get; set; }
    public int HealtPoints { get; set; }
    public float MovementSpeed { get; set; }
    public int AttackDamage { get; set; }
    public float Weight { get; set; }
    public float MinimalDistance { get; set; } 
}
