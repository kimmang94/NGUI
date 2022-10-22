using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region ΩÃ±€≈Ê
    static public SoundManager Instance;
    public void Awake()
    {
        Instance = this;
    }
    #endregion
    public enum Bgmname
    { 
        Main,
        Ari,
        Suri,
        Yeoni,
        Sani,
    }
    public enum Effectname
    { 
        Click,
        TextSound,
    }
    public enum Narrname
    {
        NarrChapter,
        NarrChant,
        NarrChallenge,
        NarrArisuCastle,
    }


    public AudioClip[] bgm;
    public AudioClip[] effect;
    public AudioClip[] narr;

    public AudioSource bgmPlayer;
    public AudioSource effectPalyer;
    public AudioSource narrPlayer;

    public GameObject EffectPrefab;
    /*
    IEnumerator Start()
    {
        bgmPlayer = GetComponent<AudioSource>();
        yield return new WaitForSeconds(3f);
        //bgmPlayer.clip = GET_BGM(Bgmname.Main);
        //bgmPlayer.Play();
    }
    */
    public void BgmSound (Bgmname name)
    {
        if(ie_bgmSound == null)
        {
            ie_bgmSound = ie_BgmSound(name);
            StartCoroutine(ie_bgmSound);
        }
    }
    public void BgmSound(bool Enable)
    {
        StartCoroutine(volumControll(Enable));
    }

    IEnumerator ie_bgmSound = null;
    IEnumerator ie_BgmSound(Bgmname name)
    {
        yield return StartCoroutine(volumControll(false));

        bgmPlayer.clip = GET_BGM(name);
        bgmPlayer.Play();

        yield return StartCoroutine(volumControll(true));
        ie_bgmSound = null;
    }

    public void EffectSound(Effectname name)
    {
        StartCoroutine(Ie_EffectSound(name));
    }
    IEnumerator Ie_EffectSound(Effectname name)
    {
        GameObject go = Instantiate(EffectPrefab);
        go.transform.parent = effectPalyer.transform;

        AudioSource effectsound = go.GetComponent<AudioSource>();
        effectsound.clip = GET_Effect(name);
        effectsound.Play();

        while (effectsound.isPlaying) yield return null;
        Destroy(go);
        
        yield return null;
    }

    public void NarrSound(Narrname name)
    {
        narrPlayer.clip = GET_NARR(name);
        narrPlayer.Play();
    }

    public void TestSound(MainFlowController.MainPage main)
    {
        EffectSound(Effectname.Click);
    }


    IEnumerator volumControll(bool Enable)
    {
        float _time = 0 ;
        float _targetTime = 0.5f;
        
        while(_time < _targetTime)
        {
            _time += Time.deltaTime;
            if (Enable) bgmPlayer.volume = (1 * (_time / _targetTime));
            else bgmPlayer.volume = 1 - (1 * (_time / _targetTime));
            yield return null;
        }
    }
    #region Custom Name
    AudioClip GET_BGM(Bgmname Name)
    {
        return bgm[(int)Name];
    }
    AudioClip GET_Effect(Effectname Name)
    {
        return effect[(int)Name];
    }
    AudioClip GET_NARR(Narrname Name)
    {
        return narr[(int)Name];
    }
    #endregion
}
