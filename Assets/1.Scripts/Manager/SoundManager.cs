using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    public float effectVolume;
    public float backgroundVolume;

    public AudioSource myBG;

    public AudioClip MainBG;
    public AudioClip PlayBG;

    Queue<GameObject> efSoundQueue = new Queue<GameObject>();


    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (SettingManager.Instance != null)
        {
            effectVolume = SettingManager.Instance.EFSound;
            backgroundVolume = SettingManager.Instance.BGSound;
        }
    }

    public void ChangeEFVolume()
    {
        effectVolume = SettingManager.Instance.EFSound;
    }

    //public GameObject CreateEffectSound(Vector3 pos)
    //{
    //    GameObject obj;

    //    if (efSoundQueue.Count == 0)
    //    {
    //        obj = Instantiate(Resources.Load("Prefabs/EfSound") as GameObject, pos, Quaternion.identity, this.transform);

    //    }
    //    else
    //    {
    //        obj = efSoundQueue.Dequeue();
    //        obj.transform.position = pos;

    //    }
    //    obj.SetActive(true);

    //    return obj;
    //}

    public void PlayMainBGSound()
    {
        myBG.volume = backgroundVolume;
        myBG.clip = MainBG;

        myBG.Play();
    }

    public void PlayPlayBGSound()
    {
        myBG.volume = backgroundVolume;
        myBG.clip = PlayBG;

        myBG.Play();
    }

    public void ChangeBGVolume()
    {
        backgroundVolume = SettingManager.Instance.BGSound;
        myBG.volume = backgroundVolume;
    }

    public void PlayEfSound(Vector3 pos, AudioClip efs)
    {
        GameObject obj = null;

        if (efSoundQueue.Count == 0)
        {
            obj = Instantiate(Resources.Load("Prefabs/EfSound") as GameObject, pos, Quaternion.identity, this.transform);

        }
        else
        {
            obj = efSoundQueue.Dequeue();
            obj.transform.position = pos;

        }
        obj.SetActive(true);

        StartCoroutine(PlayingEFSound(obj, efs));
    }

    IEnumerator PlayingEFSound(GameObject obj, AudioClip efs)
    {
        AudioSource myClip = obj.GetComponent<AudioSource>();
        myClip.clip = efs;
        myClip.volume = effectVolume;

        myClip.Play();

        while (myClip.isPlaying)
        {
            yield return null;
        }

        efSoundQueue.Enqueue(obj);
        obj.SetActive(false);
    }
}
