using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Projectiles : MonoBehaviour
{
    public float speed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);  // setting velocity just one time when we start the object
        Destroy(gameObject, lifetime); //lifetime is 2 seconds and will destroy itself after which
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Squished")
        {
            collision.gameObject.GetComponent<EnemyWalker>().isDead();
            Destroy(gameObject); //destroys projectile
        }
    }


}