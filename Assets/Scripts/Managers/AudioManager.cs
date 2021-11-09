using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    internal enum AudioClipsEnum
    {
        CollidedWithWall = 0,
        DiamondCollected,
        FlagPop,
        MagnetPick,
        SurfaceCubeCollected,
    }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    public void PlaySound(int val)
    {
        audioSource.clip = audioClips[val];
        audioSource.Play();
    }
}
