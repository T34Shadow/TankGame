using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canister : MonoBehaviour
{
    public float timer = 5;
    [SerializeField] private GameObject canister;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            Object.Destroy(canister, timer);
        
    }
}
