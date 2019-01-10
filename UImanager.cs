using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Slider PlayerHP = null;
    [SerializeField] Image HpColor;


	void Start ()
    {
        HpColor = GameObject.Find("HP").GetComponent<Image>();
        HpColor.color = new Color((float)26/255, 1, 0, (float)200/255);
    }
	
	void Update ()
    {
        HPUpdate();
    }

    void HPUpdate()
    {
        PlayerHP.value = Player.Instance.HP;

        Color ChangeColor = HpColor.color;

        if(Player.Instance.HP > (Player.Instance.MAX_HP * 0.5f))
        {
            ChangeColor = new Color((float)26 /255, 1, 0, (float)200 /255);
            HpColor.color = ChangeColor;
        }
        if(Player.Instance.HP <= (Player.Instance.MAX_HP * 0.3f))
        {
            ChangeColor = new Color(1, 0, 0, (float)200/255);
            HpColor.color = ChangeColor;
        }
        if(Player.Instance.HP <= (Player.Instance.MAX_HP * 0.5f) && Player.Instance.HP > (Player.Instance.MAX_HP * 0.3f))
        {
            ChangeColor = new Color(1, (float)100/255, 0, (float)200 /255);
            HpColor.color = ChangeColor;
        }
    }
}
