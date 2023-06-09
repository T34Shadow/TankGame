using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject shellObject;


    public Vector3 vel = new Vector3();
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float RayLength = 0.7f;

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
        Vector3 pos = shellObject.transform.position;


        vel += acc * Time.deltaTime;
        pos += vel * Time.deltaTime;

        Vector3 dir = transform.forward;
        bool hitSomething = Physics.Raycast(pos, dir, out RaycastHit hitInfo, RayLength);

        Debug.DrawRay(pos, dir, Color.red);
        if (hitSomething)
        {
            float overLapDepth = RayLength - hitInfo.distance;
            pos.z += overLapDepth;
            //Instantiate
            GameObject.Destroy(shellObject);
        }



        transform.position = pos;
    }
}
