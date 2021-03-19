using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{


    //creating an enumerated value namespace
    public enum CollectibleType
    {
        //Creating fiff types of collectibles that is kept track of (Can potentially be part of the UI)
        POWERUP,
        COLLECTIBLE,
        LIVES,
        KEY
    }

    public CollectibleType currentCollectible;
    public AudioClip collisionClip;
    AudioSource pickupAudio;
    BoxCollider2D trigger;

    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
        trigger = GetComponent<BoxCollider2D>();
        if(pickupAudio)
        {
            pickupAudio.clip = collisionClip;
            pickupAudio.loop = false;
        }
    }

    private void Update()
    {
        if(!pickupAudio.isPlaying && !trigger.enabled)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    Debug.Log("Collectible");
                    //collision.GetComponent<PlayerMovement>().score++;
                    pickupAudio.Play();
                    trigger.enabled = false; //disabling the collision box so that the player passes through it only once.
                    break;

                case CollectibleType.POWERUP:
                    Debug.Log("Powerup");
                    collision.GetComponent<PlayerMovement>().StartJumpforceChange();
                    Destroy(gameObject);
                    break;

                case CollectibleType.LIVES:
                    Debug.Log("Lives");
                    collision.GetComponent<PlayerMovement>().lives++;
                    Destroy(gameObject);
                    break;
            }
        }
    }


}