using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int sheepSaved; 

    [HideInInspector]
    public int sheepDropped; 

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner; 

    
    void Awake()
    {
        Instance = this;

    }
    public void SavedSheep()
    {    sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();

        
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }


    private void GameOver()
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.destroySheep();
        UIManager.Instance.ShowGameOverWindow();

    }
    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();


        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }
}
