using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithSonName : MonoBehaviour
{
    [Header("logic")]
    private Camera cam;

    public Transform blacksmithSonPos;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(new Vector3(blacksmithSonPos.position.x, blacksmithSonPos.position.y + 0.5f, blacksmithSonPos.position.z));
        this.gameObject.transform.position = pos;
    }
}
