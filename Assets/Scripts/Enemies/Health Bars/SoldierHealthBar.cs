using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierHealthBar : MonoBehaviour
{
    //Public
    public float currentHealth;

    //Private
    private float maxhealth = 35f;
    private Soldier soldier;
    private Image healthBar;

    private void Start()
    {
        //Find
        healthBar = GetComponent<Image>();
        soldier = FindObjectOfType<Soldier>();
    }

    private void Update()
    {
        currentHealth = soldier.soldierLife;
        healthBar.fillAmount = currentHealth / maxhealth;
    }
}
