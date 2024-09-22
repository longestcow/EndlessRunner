using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource sfxObject;
    public AudioClip startButton;
    public AudioClip menuMusic,gameMusic;
    public AudioClip shoot, reload, enemyDie, playerDie, vaultSlamSmall, vaultSlamBig, vaultUnslam, vaultWarning;


    


    public void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if(instance==null)
            instance=this;
    }

    public void playSFX(AudioClip clip, Transform spawnpoint, float volume){
        AudioSource source = Instantiate(sfxObject, spawnpoint.position, Quaternion.identity);
        source.clip = clip;
        source.volume=volume/1.7f;
        source.Play();
        Destroy(source.gameObject, source.clip.length);
    }
}
