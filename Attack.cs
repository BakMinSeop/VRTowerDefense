using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
	public Transform bulletImpact;
	ParticleSystem bulletps;

    Enemy EnemyOBJ = null;

	void Start()
	{

        if (bulletImpact)
        {
            bulletps = bulletImpact.GetComponent<ParticleSystem>();
        }
	}

    void Update ()
    {
        ShootAttack();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 200, Color.red);
    }

    void ShootAttack()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (bulletImpact)
                {
                    bulletImpact.up = hitInfo.normal;
                    bulletImpact.position = hitInfo.point + hitInfo.normal * 0.2f;
                    bulletps.Stop();
                    bulletps.Play();

                    bulletImpact.GetComponent<AudioSource>().Stop();
                    bulletImpact.GetComponent<AudioSource>().Play();
                }

                if (hitInfo.transform.tag == "Enemy")
                {
                    EnemyOBJ = hitInfo.transform.GetComponent<Enemy>();
                    EnemyOBJ.EnemyHP -= 10;
                }

                if (hitInfo.transform.tag == "Exit")
                {
                    Application.Quit();
                }

                if (hitInfo.transform.tag == "Restart")
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (bulletImpact)
                {
                    bulletImpact.GetComponent<AudioSource>().Stop();
                    bulletImpact.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
