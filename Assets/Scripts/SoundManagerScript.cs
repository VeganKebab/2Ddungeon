using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip hitSound;

    private static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("hit");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hitsound":
                 audioSrc.PlayOneShot(hitSound);
                 break;
        }
    }
}
