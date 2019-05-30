using System;
using System.Collections;
using UnityEngine;

public class IAEnemiga : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float freq = 10f;
    public GameObject Model;
    public float deltatime = 0;

    //hecho por mi
    public float MoveSpeed;
    public float MaxDist;
    public float MinDist;
    public GameObject player = GameObject.FindWithTag("Player");


    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;
        float distancia = Vector3.Distance(enemyPos, playerPos);

        if (distancia >= MinDist && distancia <= MaxDist)
        {
            Vector3 targetPos = new Vector3(player.transform.position.x,
            this.transform.position.y,
            player.transform.position.z);
            transform.LookAt(targetPos);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }

        moveDirection = new Vector3(UnityEngine.Random.Range(0, 3)-1, 0, 0);
        moveDirection = moveDirection.x != 0 ? moveDirection : new Vector3(0, 0,UnityEngine.Random.Range(0, 3)-1);
        moveDirection *= speed;

        if (deltatime >= freq)
        {
            //if (moveDirection.z < 0) { Model.transform.localRotation = new Quaternion(0, 1, 0, 0); }
            //if (moveDirection.z > 0) { Model.transform.localRotation = new Quaternion(0, 0, 0, 0); }
            //if (moveDirection.x > 0) { Model.transform.localRotation = new Quaternion(0, 0.7f, 0, 0.7f); }
            //if (moveDirection.x < 0) { Model.transform.localRotation = new Quaternion(0, -0.7f, 0, 0.7f); }
            // Move the controller
            characterController.Move(moveDirection);
            deltatime -= freq;
            //Debug.Log(moveDirection);
        }

        //Debug.Log(Model.transform.localRotation);
        deltatime += Time.deltaTime;
        deltatime = Mathf.Min(freq, deltatime);

    }
}
