using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    public AudioSource sfxObject;
    public AudioClip startButton;
    public AudioClip menuMusic,gameMusic;
    public AudioClip shoot, reload, enemyDie, playerDie, vaultSlamSmall, vaultSlamBig, vaultUnslam, vaultWarning, jump, fall;

    AudioSource menuObject;

    
    void Start() {
        menuObject = Instantiate(sfxObject, transform.position, Quaternion.identity);
        menuObject.clip = menuMusic;
        menuObject.volume=1;
        menuObject.Play();
    }

    public void Awake(){
        DontDestroyOnLoad(this.gameObject);
        if(Instance==null)
            Instance=this;
    }

    public void playSFX(AudioClip clip, Vector3 spawnpoint, float volume){
        AudioSource source = Instantiate(sfxObject, spawnpoint, Quaternion.identity);
        source.clip = clip;
        source.volume=volume;
        source.Play();
        Destroy(source.gameObject, source.clip.length);
    }

    public void gameTransition(){
        Destroy(menuObject);
        AudioSource source = Instantiate(sfxObject, transform.position, Quaternion.identity);
        source.clip = gameMusic;
        source.volume=1;
        source.Play();
    }
}
