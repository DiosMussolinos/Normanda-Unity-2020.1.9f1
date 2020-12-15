using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGuardian : MonoBehaviour
{
    [Header("logic")]
    private Camera cam;

    public Transform riverGuardianPos;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(new Vector3(riverGuardianPos.position.x, riverGuardianPos.position.y + 1f, riverGuardianPos.position.z));
        this.gameObject.transform.position = pos;
    }
}
