using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeathBarPos : MonoBehaviour
{
    [Header("logic")]
    private Camera cam;
    private FinalBoss boss;

    public Transform bossPos;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0.75f, 0.5f, 0.5f);
        cam = Camera.main;
        boss = FindObjectOfType<FinalBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(new Vector3(bossPos.position.x, bossPos.position.y + 2f, bossPos.position.z));
        this.gameObject.transform.position = pos;

        if (boss.finalBossLife <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
