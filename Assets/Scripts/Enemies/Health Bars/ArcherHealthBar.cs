using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherHealthBar : MonoBehaviour
{
    //Public
    public float currentHealth;

    //Private
    private Image healthBar;
    private Archer archer;

    private float maxhealth = 35f;

    private void Start()
    {
        //Find
        healthBar = GetComponent<Image>();
        archer = FindObjectOfType<Archer>();
    }

    private void Update()
    {
        currentHealth = archer.archerLife;
        healthBar.fillAmount = currentHealth / maxhealth;
    }
}
