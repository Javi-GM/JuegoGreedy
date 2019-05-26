using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoti : MonoBehaviour
{
    public int HealthIncrease;



    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Rabbit_Red")
        {
            other.GetComponent<GreedyMovement>().modifyHealth(HealthIncrease);
            Destroy(this.gameObject);
        }
    }
}
