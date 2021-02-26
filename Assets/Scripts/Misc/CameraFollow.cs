using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == true)
        {
            Vector3 cameraTransform; 
            cameraTransform = transform.position;
            cameraTransform.x = player.transform.position.x - 2.5f; //camera clamping to player with offset
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, 3.25f, 186f);
            transform.position = cameraTransform;
        }
    }
}
