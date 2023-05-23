using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : MonoBehaviour
{
    //make a variable to store the shooting direction (up or down, left or right)
    public string shootingDirection = "right";

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private float shootInterval = 0.7f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //shoot a bullet every shootInterval seconds in the shootingDirection not using Couroutines
        if (Time.time % shootInterval < Time.deltaTime) {
            Shoot();
        }


    }

    void Shoot() {
        //create a new bullet object
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        //get the rigidbody2d from the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        SoundManager.PlaySound("turretFire");

        //set the velocity of the bullet to the bulletSpeed in the shootingDirection
        if (shootingDirection == "right") {
            rb.velocity = Vector2.right * bulletSpeed;
        } else if (shootingDirection == "left") {
            rb.velocity = Vector2.left * bulletSpeed;
        } else if (shootingDirection == "up") {
            rb.velocity = Vector2.up * bulletSpeed;
        } else if (shootingDirection == "down") {
            rb.velocity = Vector2.down * bulletSpeed;
        }
    }



}
