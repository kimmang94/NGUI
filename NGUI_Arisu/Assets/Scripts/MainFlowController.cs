using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlowController : MonoBehaviour
{
    static public MainFlowController Instance;
    public void Awake()
    {
        Instance = this;
    }
    public enum MainPage
    {
        Login = 0,
        Main = 1,
        Chapter = 2,
        Chant = 3,
        Challenge = 4,
        ArisuCastle = 5
    }

    public List<GameObject> prefabs;

    public MainPage currentMainpage = MainPage.Login;
    void Start()
    {
        SoundManager.Instance.BgmSound(SoundManager.Bgmname.Main);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(MainPage page)
    {
        foreach(var prefab in prefabs) {
            prefab.SetActive(false);
        }

        prefabs[(int)page].SetActive(true);

        switch (page) {
        case MainPage.Login:
            break;
        case MainPage.Main:
            
            break;
        case MainPage.Chapter:
            
            break;
        case MainPage.Chant:
                SoundManager.Instance.BgmSound(false);
            break;
        case MainPage.Challenge:
            
            break;
        case MainPage.ArisuCastle:
            
            break;
        default :
            
            break;
       }
        print("NextScene()");
    }
}
