using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Enemy : MonoBehaviour
{
    public int EnemyHP = 10;
    public Transform explosion;
    ParticleSystem explosionPs;

    void Start ()
    {
        if (explosion)
        {
            explosion = GameObject.Find("Explosion").GetComponent<Transform>();
            explosionPs = explosion.GetComponent<ParticleSystem>();
        }
    }

    void Update ()
    {
		if(EnemyHP <= 0)
        {
            EnemyDie();
        }
	}

    void EnemyDie()
    {
        if (explosion)
        {
            explosion.position = transform.position;
            explosionPs.Stop();
            explosionPs.Play();
            explosion.GetComponent<AudioSource>().Stop();
            explosion.GetComponent<AudioSource>().Play();
        }

        Destroy(transform.gameObject);
    }
}
