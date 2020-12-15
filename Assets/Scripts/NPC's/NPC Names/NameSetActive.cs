using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameSetActive : MonoBehaviour
{
    public GameObject blacksmithName;
    public GameObject blacksmithSonName;
    public GameObject riverGuardianName;

    public Transform blacksmith;
    public Transform blacksmithSon;
    public Transform riverGuardian;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float blacksmithDistance = Vector2.Distance(blacksmith.transform.position, player.transform.position);
        float blacksmithSonDistance = Vector2.Distance(blacksmithSon.transform.position, player.transform.position);
        float riverGuardianDistance = Vector2.Distance(riverGuardian.transform.position, player.transform.position);

        if (blacksmithDistance < 4)
        {
            blacksmithName.gameObject.SetActive(true);
        }

        else
        {
            blacksmithName.gameObject.SetActive(false);
        }

        if (blacksmithSonDistance < 4)
        {
            blacksmithSonName.gameObject.SetActive(true);
        }

        else
        {
            blacksmithSonName.gameObject.SetActive(false);
        }

        if (riverGuardianDistance < 4)
        {
            riverGuardianName.gameObject.SetActive(true);
        }

        else
        {
            riverGuardianName.gameObject.SetActive(false);
        }

    }
}
