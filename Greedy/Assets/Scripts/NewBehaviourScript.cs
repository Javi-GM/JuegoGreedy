using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float freq = 10f;
    public GameObject Model;

    float deltatime = 0;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Debug.Log(moveDirection);
        }

        Debug.Log(Model.transform.localRotation);
        deltatime += Time.deltaTime;
        deltatime = Mathf.Min(freq, deltatime);
    }

    void OnTriggerEnter(Collider other)
  	{
  		if (other.gameObject.CompareTag ("Carrot"))
  		{
  			other.gameObject.SetActive (false);
  		}
  	}
}
