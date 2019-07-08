using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalgorSound : MonoBehaviour
{
    public AudioClip Saut;
    public AudioClip Attaque;
    public AudioClip Marche;
    public AudioSource sourceSon;

    public void PlayJumpSound()
    {
        sourceSon.PlayOneShot(Saut);
    }

    void PlayAttackSound()
    {
        sourceSon.PlayOneShot(Attaque);
    }

    void PlayWalkSound()
    {
        sourceSon.PlayOneShot(Marche);
    }
}
