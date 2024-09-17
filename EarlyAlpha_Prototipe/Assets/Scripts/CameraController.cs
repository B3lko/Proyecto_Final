using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float z;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(Player.position.x, y, Player.position.z -z);
    }
}
