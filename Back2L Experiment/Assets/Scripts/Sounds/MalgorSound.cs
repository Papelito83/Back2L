using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Component.Sounds
{
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

        internal void PlayAttackSound()
        {
            sourceSon.PlayOneShot(Attaque);
        }

        private void PlayWalkSound()
        {
            sourceSon.PlayOneShot(Marche);
        }
    }
}
