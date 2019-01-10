using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Drone : MonoBehaviour
{
	UnityEngine.AI.NavMeshAgent agent;
	Transform tower;
	public float ATTACK_TIME = 2;
	float attackTime = 0;

	public float ATTACK_DISTANCE = 1;

    void Start ()
    {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		tower = GameObject.Find("Player").transform;

		agent.destination = tower.position;

		attackTime = ATTACK_TIME;
	}


	void Update()
	{
		if((agent.remainingDistance <= ATTACK_DISTANCE) && (agent.remainingDistance != 0))
        {
			attackTime += Time.deltaTime;
			if(attackTime > ATTACK_TIME)
			{
				attackTime = 0;
                Player.Instance.Damage();
			}
		}
    }
}
