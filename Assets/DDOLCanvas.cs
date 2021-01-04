using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOLCanvas : MonoBehaviour
{
    private Scene scene;

    private string sceneName;

    public GameObject NpcUi;

    public GameObject TextPlaque;

    void Awake() 
    {
        //Do not destroy this shit
        DontDestroyOnLoad(gameObject);

        scene = SceneManager.GetActiveScene();

        sceneName = scene.name;

        NpcUi = GameObject.Find("Canvas/GameUI/NPC UI");

        TextPlaque = GameObject.Find("Canvas/GameUI/TextPlaque");

        if ((sceneName == "D1") || (sceneName == "D2") || (sceneName == "D3"))
        {
            NpcUi.SetActive(false);
            TextPlaque.SetActive(false);
        }

        if ((sceneName == "N1") || (sceneName == "N2") || (sceneName == "N3"))
        {
            NpcUi.SetActive(true);
            TextPlaque.SetActive(true);
        }

    }
}
