using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip hitSound;
    public static AudioClip ememy1Death;
    public static AudioClip charDamage;

    private static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("hit");
        ememy1Death = Resources.Load<AudioClip>("death_enemy1");
        charDamage = Resources.Load<AudioClip>("Char_damage");
        
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hitsound":
                 audioSrc.PlayOneShot(hitSound);
                 break;
            case "enemy1death":
                audioSrc.PlayOneShot(ememy1Death);
                break;
            case "chardamage":
                audioSrc.PlayOneShot(charDamage);
                break;
        }
    }
}
