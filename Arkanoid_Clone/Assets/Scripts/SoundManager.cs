using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
    public static void PlaySound(AudioClip audioClip, string objectName)
    {
        GameObject soundGameObject = new GameObject(objectName);
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);

        Object.Destroy(soundGameObject, audioClip.length);
    }

}
