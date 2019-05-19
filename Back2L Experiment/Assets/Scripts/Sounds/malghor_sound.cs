using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malghor_sound : MonoBehaviour
{
    // Start is called before the first frame update


    public AudioClip Saut;
    public AudioClip Attaque;
    public AudioClip Marche;
    public AudioSource sourceSon;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jumpSound()
    {
        sourceSon.PlayOneShot(Saut);
    }

    void attackSound()
    {
        sourceSon.PlayOneShot(Attaque);
    }

    void walkSound()
    {
        sourceSon.PlayOneShot(Marche);
    }
}
