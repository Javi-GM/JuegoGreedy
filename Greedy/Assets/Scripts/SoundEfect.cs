using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfect : MonoBehaviour
{
    public float XDisplacement;
    public float ZDisplacement;
    public AudioSource SoundSource;
    public CharacterController Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Rabbit_Red")
        {
            SoundSource.Play();
            Player.Move(new Vector3(XDisplacement, 0, ZDisplacement));
        }
    }
}
