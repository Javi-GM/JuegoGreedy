using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int ExtraLives;



    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Rabbit_Red")
        {
            other.GetComponent<GreedyMovement>().AddLife(1);
            Destroy(this.gameObject);
        }
    }
}
