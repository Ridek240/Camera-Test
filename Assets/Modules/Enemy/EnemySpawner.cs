using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float minTime = 1f; // Minimalny czas odstêpu
    public float maxTime = 5f; // Maksymalny czas odstêpu
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InvokeRandomly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InvokeRandomly()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            if(GameMenager.Instance.EnemyLimits< GameMenager.Instance.EnemyLimitsMax)
            {
                Instantiate(enemy, transform);
                GameMenager.Instance.EnemyCounterUp();
            }
        }
    }
}
