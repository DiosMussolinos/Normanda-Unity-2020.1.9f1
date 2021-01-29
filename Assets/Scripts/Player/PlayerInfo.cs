using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerInfo : MonoBehaviour
{
    public string username;
    public int user_id;

    public PlayerInfo(string uName, int uID)
    {
        username = uName;
        user_id = uID;
    }

}
