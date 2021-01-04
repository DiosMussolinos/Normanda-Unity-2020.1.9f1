using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameSetActive : MonoBehaviour
{
    //Scene Related
    private Scene scene;
    private string sceneName;

    //NPC's
    public GameObject blacksmithName;
    public GameObject blacksmithSonName;
    public GameObject riverGuardianName;
    public GameObject NpcUi;
    //NPC's position
    public Transform blacksmith;
    public Transform blacksmithSon;
    public Transform riverGuardian;
    //Player
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //Get Scene Name
        scene = SceneManager.GetActiveScene();
        //String it
        sceneName = scene.name;
        //PlayerPos
        player = GameObject.FindWithTag("Player").transform;
        //NpcUi
        NpcUi = GameObject.FindGameObjectWithTag("NpcUI");

        if (sceneName != "N1")
        {
            NpcUi.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "N1")
        {
            float blacksmithDistance = Vector2.Distance(blacksmith.transform.position, player.transform.position);
            float blacksmithSonDistance = Vector2.Distance(blacksmithSon.transform.position, player.transform.position);
            float riverGuardianDistance = Vector2.Distance(riverGuardian.transform.position, player.transform.position);

            if ((blacksmithDistance < 4) && (sceneName == "N1"))
            {
                blacksmithName.gameObject.SetActive(true);
            }
            else
            {
                blacksmithName.gameObject.SetActive(false);
            }

            if ((blacksmithSonDistance < 4) && (sceneName == "N1"))
            {
                blacksmithSonName.gameObject.SetActive(true);
            }
            else
            {
                blacksmithSonName.gameObject.SetActive(false);
            }

            if ((riverGuardianDistance < 4) && (sceneName == "N1"))
            {
                riverGuardianName.gameObject.SetActive(true);
            }
            else
            {
                riverGuardianName.gameObject.SetActive(false);
            }
        }
        else
        {
            NpcUi.SetActive(false);
        }
    }
}
