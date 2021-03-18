using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class PlayerFire : MonoBehaviour
{
    SpriteRenderer marioSprite;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectiles projectilesPrefab;


    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }

        if (!spawnPointLeft || !spawnPointRight || !projectilesPrefab)
        {
            Debug.Log("Unity inspector value is not set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                FireProjectile();
            }
        }
    }

    void FireProjectile()
    {
        if (marioSprite.flipX)
        {
            Debug.Log("Fire left");
            Projectiles projectileInstance = Instantiate(projectilesPrefab, spawnPointLeft.position, spawnPointLeft.rotation); //unity function 'instantiate()' will take a refernece to the object or to be created, will take vector 3 position and its rotation
            projectileInstance.speed = projectileSpeed * -1;

        }
        else
        {
            Debug.Log("Fire Right");
            Projectiles projectileInstance = Instantiate(projectilesPrefab, spawnPointRight.position, spawnPointRight.rotation); //unity function 'instantiate()' will take a refernece to the object or to be created, will take vector 3 position and its rotation
            projectileInstance.speed = projectileSpeed;
        }
    }
}
