using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Gravity : MonoBehaviour
{

    [SerializeField] private Vector3 vel = new Vector3();
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float RayLength = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 acc = new Vector3(0f, -gravity, 0f);
        Vector3 dir = -transform.up;
        bool hitSomething = Physics.Raycast(pos, dir, out RaycastHit hitInfo, RayLength);
        
        if (hitSomething)
        {
            //if (hitInfo.)
            float overLapDepth = RayLength - hitInfo.distance;
            pos.y += overLapDepth;
            vel.y = 0f;
        }

        vel += acc * Time.deltaTime;
        pos += vel * Time.deltaTime;

        transform.position = pos;

    }
}
