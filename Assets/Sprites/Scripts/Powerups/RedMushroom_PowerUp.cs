using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom_PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Destroy(gameObject);
    }
}
