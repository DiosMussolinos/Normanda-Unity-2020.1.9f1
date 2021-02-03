using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////USER ID\\\\\\\\\\\\
[System.Serializable]
public class PlayerInfo
{
    public int user_id;

    public PlayerInfo(int i)
    {
        user_id = i;
    }
}
///////////USER ID\\\\\\\\\\\\

///////////USER HP\\\\\\\\\\\\
[System.Serializable]
public class PlayerHP
{
    public int user_hp;

    public PlayerHP(int h)
    {
        user_hp = h;
    }
}
///////////USER ID\\\\\\\\\\\\

///////////NEW USER HP\\\\\\\\\\\\
[System.Serializable]
public class PlayerNewHp
{
    public int user_hp;
    public int user_id;

    public PlayerNewHp(int h, int i)
    {
        user_hp = h;
        user_id = i;
    }
}
///////////NEW USER HP\\\\\\\\\\\\

///////////NEW USER Level\\\\\\\\\\\\
[System.Serializable]
public class PlayerNewLevel
{
    public int user_level;
    public int user_id;

    public PlayerNewLevel(int l, int i)
    {
        user_level = l;
        user_id = i;
    }
}
///////////NEW USER LEVEL\\\\\\\\\\\\

///////////NEW USER XP\\\\\\\\\\\\
[System.Serializable]
public class PlayerNewExp
{
    public int user_exp;
    public int user_id;

    public PlayerNewExp(int e, int i)
    {
        user_exp = e;
        user_id = i;
    }
}
///////////NEW USER XP\\\\\\\\\\\\

///////////NEW USER GOLD\\\\\\\\\\\\
[System.Serializable]
public class PlayerNewGold
{
    public int user_gold;
    public int user_id;

    public PlayerNewGold(int g, int i)
    {
        user_gold = g;
        user_id = i;
    }
}
///////////NEW USER GOLD\\\\\\\\\\\\

///////////LOGIN\\\\\\\\\\\\
[System.Serializable]
public class Login
{
    public string user_name;
    public string user_password;

    public Login(string u, string p)
    {
        user_name = u;
        user_password = p;
    }
}
///////////LOGIN\\\\\\\\\\\\

///////////REGISTER\\\\\\\\\\\\
[System.Serializable]
public class NewPlayerInfo
{
    public string user_name;
    public string user_password;

    public NewPlayerInfo(string u, string p)
    {
        user_name = u;
        user_password = p;
    }
}
///////////REGISTER\\\\\\\\\\\\

///////////BUY_ITEM\\\\\\\\\\\\
[System.Serializable]
public class BuyItem
{
    public int id;
    public string item_id;
    public int item_amount;
    

    public BuyItem(int i, string iTid, int a)
    {
        id = i;
        item_id = iTid;
        item_amount = a;
    }
}
///////////BUY_ITEM\\\\\\\\\\\\

///////////Post_INVENTORY\\\\\\\\\\\\
[System.Serializable]
public class GetItemsID
{
    public string item_id;


    public GetItemsID(string iTid)
    {
        item_id = iTid;
    }
}


[System.Serializable]
public class GetItemsAmount
{
    public int item_amount;

    public GetItemsAmount(int a)
    {
        item_amount = a;
    }
}

[System.Serializable]
public class ItemsInfo
{
    public int id;
    public string item_id;
    public int item_amount;


    public ItemsInfo(int i, string iTid, int a)
    {
        id = i;
        item_id = iTid;
        item_amount = a;
    }
}

[System.Serializable]
public class ItemsNumber
{
    public ItemsNumber[] itemsAmountGet;
}

[System.Serializable]
public class itemID
{
    public string[] GetItemsID;
}


///////////GET_INVENTORY\\\\\\\\\\\\
