using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithName : MonoBehaviour
{
    [Header("logic")]
    private Camera cam;

    public Transform blacksmithPos;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 pos = cam.WorldToScreenPoint(new Vector3(blacksmithPos.position.x, blacksmithPos.position.y + 1f, blacksmithPos.position.z));
        this.gameObject.transform.position = pos;
    }
}
