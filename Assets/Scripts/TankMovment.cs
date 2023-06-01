using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using static UnityEditor.PlayerSettings;

public class TankMovment : MonoBehaviour
{
    //Tank movement


    Vector3 vel;
    [Header("TankMovement")]
    public float speed;
    public float maxGroundForce;
    public Transform tankPos;
    public float rotationSpeed;
    [Header("TurretMovement")]
    public float turretRotationSpeed;
    public Transform turretOrientaion;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Tank Movement
        float Movement = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        Vector3 acc = new Vector3(0f, -9.81f, 0f);

        float desiredSpeed = Movement * speed;


        float actualSpeed = vel.z;

        float desiredChangeSpeed = desiredSpeed - actualSpeed;
        float desiredAcc = desiredChangeSpeed / Time.deltaTime;

        float actualAcc;

        actualAcc = Mathf.Clamp(desiredAcc, -maxGroundForce, maxGroundForce);
        acc.z = actualAcc;

        vel += acc * Time.deltaTime;
        pos += vel * Time.deltaTime;

        tankPos.position = pos;

        //tanks pos on ground with raycast
        RaycastHit hitInfo = Physics.Raycast(pos, Vector3.down, 0.5f);
        if (hitInfo)
        {
            float overLapDepth = 0.5f - hitInfo.distance;
            pos.y += overLapDepth;
        }

        //Tank rotation

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }

    }

}

