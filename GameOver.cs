using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;
    [SerializeField] GameObject[] EnemyOBJ;
    [SerializeField] GameObject[] SpawnPoint;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void StopSpawn()
    {
        EnemyOBJ = GameObject.FindGameObjectsWithTag("Enemy");
        SpawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for (int i = 0; i < EnemyOBJ.Length; i++)
        {
            Destroy(EnemyOBJ[i]);
        }

        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            SpawnPoint[i].SetActive(false);
        }
    }
}
