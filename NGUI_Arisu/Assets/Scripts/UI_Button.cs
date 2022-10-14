using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    public GameObject Invoker;
    public string method;

    public Color pressColor;
    UITexture uITexture;
    UILabel uiLabel;

    TweenColor tween;

    void Start()
    {
        if(uITexture != null) uITexture = GetComponent<UITexture>();
        if(uiLabel != null) uiLabel = GetComponent<UILabel>();
    }

    Dictionary<string, bool> dic;

    void OnPress(bool isPress)
    {
        if (!isPress)
        {
            Invoker.SendMessage(method, isPress);
            print("11" + isPress);
        }
        
    }

    void OnHover()
    {
        print("OnMouseOver");
        if (uITexture != null) uITexture.color = pressColor;
        if (uiLabel != null) uiLabel.color = pressColor;
    }
}