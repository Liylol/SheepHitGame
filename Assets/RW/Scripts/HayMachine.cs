using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movSpeed;
    public float boundary = 22f;

    public GameObject HayBale;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;

    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
    void UpdateMovement()
    {
        float HorizontalMovement = Input.GetAxisRaw("Horizontal");

        
        if (HorizontalMovement < 0 && transform.position.x > -boundary)
        {
            transform.Translate(transform.right * -movSpeed * Time.deltaTime);
        }
        
        if (HorizontalMovement > 0 && transform.position.x < boundary)
        {
            transform.Translate(transform.right * movSpeed * Time.deltaTime);
        }
    }

    void ShootHay()
    {
        Instantiate(HayBale, haySpawnpoint.position, Quaternion.identity);
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }


}
