using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BackGoundMusic
{
    None,
    BackGroundMusicInMenu,
    BackGroundMusicInOption,
    BackGroundMusicInPause,
    BackGroundMusicInPlay,
}

public enum SoundEffect
{
    PlayerMoveOnGrass,
    PlayerMoveOnMud,
    PlayerMoveOnStone,
    PlayerPlantSeed,
}

public class SoundManager:ISingletonMonoBehaviour<SoundManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    private SoundSettingInfor soundSettingInfor;


    protected override void Awake()
    {
       base.Awake();
        soundSettingInfor = Resources.Load<SoundSettingInfor>("SoundSettingInfor");
    }

    public void PlaySound(BackGoundMusic backGoundMusic)
    {
        musicSource.clip = soundSettingInfor.GameBackgroundMusic.Find(music => music.id == backGoundMusic).audioClip;
        musicSource.volume = 1;
        musicSource.loop = true;
        musicSource.Play();
    }

}
