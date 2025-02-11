using UnityEngine;
using System;
using TMPro;
public class GameMenager : MonoBehaviour
{

    public static GameMenager Instance;
    public event EventHandler UpdateStats;
    public int EnemyLimits = 0;
    public int EnemyLimitsMax = 20;
    public int EnemyKilled = 0;

    public TextMeshProUGUI EnemyLimitCounter;
    public TextMeshProUGUI EnemyKilledCounter;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void EnemyCounterUp()
    {
        EnemyLimits++;
        UpdateCounters();
    }
    public void EnemyCounterDown()
    {
        EnemyLimits--;
        EnemyKilled++;
        UpdateCounters();
    }
    public void UpdateCounters()
    {
        EnemyKilledCounter.text = EnemyKilled.ToString();
        EnemyLimitCounter.text = EnemyLimits.ToString();
    }
}
