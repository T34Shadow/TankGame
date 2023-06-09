using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerSpwaner;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = playerSpwaner.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
