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
    public GameObject Npc4;
    public GameObject Npc5;
    public GameObject Npc6;
    public GameObject Npc7;



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
            Npc4.gameObject.SetActive(true);
            Npc5.gameObject.SetActive(true);
            Npc6.gameObject.SetActive(true);
            Npc7.gameObject.SetActive(true);
        }

    }
}
