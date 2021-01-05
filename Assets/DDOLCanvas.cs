using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOLCanvas : MonoBehaviour
{
    public static DDOLCanvas canvasExist;

    private Scene scene;

    private string sceneName;

    //N1
    public GameObject BlacksmithName;
    public GameObject BlacksmithSonName;
    public GameObject RiverGuardianName;
    //N2
    //public GameObject BlacksmithName;
    //public GameObject BlacksmithName;
    //public GameObject BlacksmithName;
    //N3
    //public GameObject BlacksmithName;
    //public GameObject BlacksmithName;


    void Awake() 
    {

        /*
        if (canvasExist != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }*/
         
        
        /*if (sceneName != "N1" || sceneName != "N2")
        {
            //Do not destroy this shit
            DontDestroyOnLoad(gameObject);
        }*/
        DontDestroyOnLoad(gameObject);

        scene = SceneManager.GetActiveScene();

        sceneName = scene.name;

        BlacksmithName = GameObject.Find("Canvas/GameUI/NPC UI/Blacksmith Name");
        BlacksmithSonName = GameObject.Find("Canvas/GameUI/NPC UI/Blacksmith Son Name");
        RiverGuardianName = GameObject.Find("Canvas/GameUI/NPC UI/River Guardian Name");


        if (sceneName == "N1")
        {
            BlacksmithName.SetActive(true);
            BlacksmithSonName.SetActive(true);
            RiverGuardianName.SetActive(true);
        }
        else
        {
            BlacksmithName.SetActive(false);
            BlacksmithSonName.SetActive(false);
            RiverGuardianName.SetActive(false);
        }


    }
}
