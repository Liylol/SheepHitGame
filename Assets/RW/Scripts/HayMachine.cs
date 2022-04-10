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
    public Transform modelParent; 
    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
     void Start()
    {
        LoadModel();

    }
    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject);

        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
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
        SoundManager.Instance.PlayShootClip();

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
