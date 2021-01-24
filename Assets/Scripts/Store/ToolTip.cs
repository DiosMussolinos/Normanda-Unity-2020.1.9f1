using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public Text lore;
    public Text details;

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

    public void UpdateToolTip(string _details, string _lore)
    {
        
        details.text = _details;
        lore.text = _lore;
    }

    public void SetPos(Vector2 _pos) 
    {
        transform.localPosition = _pos;
    }

}
