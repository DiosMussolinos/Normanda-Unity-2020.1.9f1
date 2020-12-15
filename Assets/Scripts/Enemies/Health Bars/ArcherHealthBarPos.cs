using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHealthBarPos : MonoBehaviour
{

    [Header("logic")]
    private Camera cam;
    private Archer archer;

    public Transform archerPos;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cam = Camera.main;
        archer = FindObjectOfType<Archer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(new Vector3(archerPos.position.x, archerPos.position.y + 1f, archerPos.position.z));
        this.gameObject.transform.position = pos;

        if (archer.archerLife <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
