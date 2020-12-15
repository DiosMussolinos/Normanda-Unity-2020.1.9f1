using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    //Public
    public float currentHealth;

    //Private
    private float maxhealth = 35f;
    private FinalBoss boss;
    private Image healthBar;

    private void Start()
    {
        //Find
        healthBar = GetComponent<Image>();
        boss = FindObjectOfType<FinalBoss>();
    }

    private void Update()
    {
        currentHealth = boss.finalBossLife;
        healthBar.fillAmount = currentHealth / maxhealth;
    }
}
