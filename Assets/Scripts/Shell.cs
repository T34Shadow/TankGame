using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Shell : MonoBehaviour
{
    public float speed;
    public GameObject Shell01;
    public Vector3 vel = new Vector3();
    public float gravity = 9.81f;

    //before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 acc = new Vector3(0f, -gravity, 0f);

        float desSpeed = speed * Time.deltaTime;
        transform.Translate(0f, 0f, desSpeed);
        Vector3 pos = transform.position;

        bool hitSomething = Physics.Raycast(pos, Vector3.forward, out RaycastHit hitInfo, 0.5f);
        if (hitSomething)
        {
            //if (hitInfo.)
            float overLapDepth = 0.5f - hitInfo.distance;
            pos.z += overLapDepth;

            GameObject.Destroy(Shell01);
        }

        vel += acc * Time.deltaTime;
        pos += vel * Time.deltaTime;

        transform.position = pos;
    }
}
