using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    AudioClip c1;
    AudioClip c2;
    AudioSource au;
    Scene scene;

    private void Start()
    {
        au = GetComponent<AudioSource>();
        au.clip = clips[0];
        c1 = clips[0];
    }

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);

        scene = SceneManager.GetActiveScene();

        if (scene.buildIndex <= 2)
        {
            au.clip = clips[0];
            c1 = au.clip;
        }   else if (scene.buildIndex >= 3) { au.clip = clips[1]; c1 = au.clip; }

        if (c1 != c2)
        {
            au.Play();
            c2 = c1;
        }
        Debug.Log(c1);
        Debug.Log(c2);
    }
}
