using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOLCanvas : MonoBehaviour
{
    public static DDOLCanvas canvasExist;

    private Scene scene;

    private string sceneName;

    public GameObject Npc1;
    public GameObject Npc2;
    public GameObject Npc3;
    //public GameObject Npc4;
    //public GameObject Npc5;



    void Awake() 
    {
        DontDestroyOnLoad(gameObject);

    }

    void Update() 
    {
        scene = SceneManager.GetActiveScene();

        sceneName = scene.name;

        if (sceneName == "N1")
        {
            Npc1.gameObject.SetActive(true);
            Npc2.gameObject.SetActive(true);
            Npc3.gameObject.SetActive(true);
        }

    }
}
