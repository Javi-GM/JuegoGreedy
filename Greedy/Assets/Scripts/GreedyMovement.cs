using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreedyMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float freq = 10f;
    public GameObject Model;
    public float deltatime = 0;
    public Text textCalorias;
    private int calorias;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        textCalorias.text = "Calorías: " + 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCaloriesUI();

        moveDirection = new Vector3();
        moveDirection.x = Input.GetAxis("Horizontal")==0 ? 0 : Mathf.Sign(Input.GetAxis("Horizontal"));
        moveDirection.z = Input.GetAxis("Vertical") == 0 ? 0 : Mathf.Sign(Input.GetAxis("Vertical"));
        moveDirection *= speed;

        if (deltatime >= freq && (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0))
        {
            if (moveDirection.z < 0){ Model.transform.localRotation=new Quaternion(0,1,0,0); }
            if (moveDirection.z > 0) { Model.transform.localRotation = new Quaternion(0, 0, 0, 0); }
            if (moveDirection.x > 0) { Model.transform.localRotation = new Quaternion(0, 0.7f, 0, 0.7f); }
            if (moveDirection.x < 0) { Model.transform.localRotation = new Quaternion(0, -0.7f, 0, 0.7f); }
            // Move the controller
            characterController.Move(moveDirection);
            deltatime -=freq;
            //Debug.Log(moveDirection);
        }

        //Debug.Log(Model.transform.localRotation);
        deltatime += Time.deltaTime;
        deltatime = Mathf.Min(freq, deltatime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SmallCarrot"))
        {
            other.gameObject.SetActive(false);
            calorias += 10;

        }

        if (other.gameObject.CompareTag("MediumCarrot"))
        {
            other.gameObject.SetActive(false);
            calorias += 20;

        }

        if (other.gameObject.CompareTag("BigCarrot"))
        {
            other.gameObject.SetActive(false);
            calorias += 30;

        }

        if (other.gameObject.CompareTag("SmallBanana"))
        {
            other.gameObject.SetActive(false);
            calorias += 5;

        }

        if (other.gameObject.CompareTag("MediumBanana"))
        {
            other.gameObject.SetActive(false);
            calorias += 10;

        }

        if (other.gameObject.CompareTag("BigBanana"))
        {
            other.gameObject.SetActive(false);
            calorias += 15;

        }
    }

    void UpdateCaloriesUI()
    {
        textCalorias.text = "Calorías: " + calorias.ToString();
    }
}
