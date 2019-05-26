using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGenerator : MonoBehaviour
{
    public GameObject pickup;
    public int minX, minY;
    public int maxX, maxY;
    public int quantity;
    public int frequency;
    public int altura;
    public float desplazamiento;

    float time;

    private void Start()
    {
        time = Random.Range(0, frequency)+10;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0 && quantity > 0)
        {
            quantity--;
            time = Random.Range(0, frequency) * 100;

            Instantiate(pickup,new Vector3(Random.Range(minX,maxX), altura , Random.Range(minY, maxY)+desplazamiento), Quaternion.identity);
        }

        time -= Time.deltaTime;

    }
}
