using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public Text type;
    public Text descripion;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateToolTip(string _type, string _descripion)
    {

        type.text = _type;
        descripion.text = _descripion;
    }

    public void SetPos(Vector2 _pos) 
    {
        transform.localPosition = _pos;
    }

}
