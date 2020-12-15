using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealthBarPos : MonoBehaviour
{
    [Header("logic")]
    private Camera cam;
    private Soldier soldier;

    public Transform soldierPos;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cam = Camera.main;
        soldier = FindObjectOfType<Soldier>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(new Vector3(soldierPos.position.x, soldierPos.position.y + 1f, soldierPos.position.z));
        this.gameObject.transform.position = pos;

        if (soldier.soldierLife <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
