using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameBackgroundMusic
{
    public BackGoundMusic id;
    public AudioClip audioClip;
}

[Serializable]
public class GameSoundEffect
{ 
    public SoundEffect id;
    public AudioClip audioClip;
}

[CreateAssetMenu(fileName = "SoundSettingInfor", menuName = "ScriptableObjects/ SoundSettingInfor", order = 1)]

public class SoundSettingInfor : ScriptableObject
{
    public List<GameBackgroundMusic> GameBackgroundMusic;
    [field: SerializeField] 
    public List<GameSoundEffect> GameSoundEffect;
}
