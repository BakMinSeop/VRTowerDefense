using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float MIN_TIME = 1;
    public float MAX_TIME = 5;

    void Start()
    {
        StartCoroutine("CreateEnemy");
    }

    IEnumerator CreateEnemy()
    {
        while (Application.isPlaying)
        {
            float createTime = Random.Range(MIN_TIME, MAX_TIME);
            yield return new WaitForSeconds(createTime);

            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}

