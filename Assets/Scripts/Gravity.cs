using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Gravity : MonoBehaviour
{

    public Vector3 vel = new Vector3();
    public float gravity = 9.81f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 acc = new Vector3(0f, -gravity, 0f);

        bool hitSomething = Physics.Raycast(pos, Vector3.down, out RaycastHit hitInfo, 0.5f);

        if (hitSomething)
        {
            //if (hitInfo.)
            float overLapDepth = 0.5f - hitInfo.distance;
            pos.y += overLapDepth;
            vel.y = 0f;
        }

        vel += acc * Time.deltaTime;
        pos += vel * Time.deltaTime;

        transform.position = pos;

    }
}
