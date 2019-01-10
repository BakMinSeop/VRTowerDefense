using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player Instance;

	public int MAX_HP = 10;
    [HideInInspector] public int HP = 0;

	public GameObject GameOverUI;

	void Awake()
	{
        if(Instance == null)
        {
            Instance = this;
        }
	}

	void Start()
	{
		HP = MAX_HP;
        GameOverUI.SetActive(false);
	}

	public void Damage()
	{
		HP--;

		if(HP <= 0)
		{
			if(GameOverUI)
			{
				GameOverUI.SetActive(true);
			}

            GameOver.Instance.StopSpawn();
		}
	}
}
