using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    //Public
    public GameObject bossHB;
    public GameObject archerHB;
    public GameObject soldierHB;

    //Private
    private Transform player;
    private Transform boss;
    private Transform archer;
    private Transform soldier;

    private FinalBoss finalBossScript;
    private Archer archerScript;
    private Soldier soldierScript;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        boss = GameObject.FindWithTag("FinalBoss").transform;
        archer = GameObject.FindWithTag("Archer").transform;
        soldier = GameObject.FindWithTag("Soldier").transform;

        finalBossScript = FindObjectOfType<FinalBoss>();
        archerScript = FindObjectOfType<Archer>();
        soldierScript = FindObjectOfType<Soldier>();

    }

    // Update is called once per frame
    void Update()
    {
        if (finalBossScript.finalBossLife > 0)
        {
            float bossDistance = Vector2.Distance(boss.transform.position, player.transform.position);

            if (bossDistance < 4)
            {
                bossHB.gameObject.SetActive(true);
            }
        }

        if (archerScript.archerLife > 0)
        {
            float archerDistance = Vector2.Distance(archer.transform.position, player.transform.position);

            if (archerDistance < 4)
            {
                archerHB.gameObject.SetActive(true);
            }
        }

        if (soldierScript.soldierLife > 0)
        {
            float soldierDistance = Vector2.Distance(soldier.transform.position, player.transform.position);

            if (soldierDistance < 4)
            {
                soldierHB.gameObject.SetActive(true);
            }
        }
    }
}
