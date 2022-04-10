using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{  
    public bool canSpawn = false;
    public GameObject sheepPrefab;
    public List<Transform> sheepSpawnPosition = new List<Transform>();
    public float timeBetweenSpawns;
    private List<GameObject> sheepList = new List<GameObject>();
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

  
   

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPosition[Random.Range(0, sheepSpawnPosition.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab,randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);

    }

    private IEnumerator SpawnRoutine()
    {

        while (canSpawn)
        {

            SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);


    }
    public void destroySheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep); 
        }
        sheepList.Clear();
    }

}
