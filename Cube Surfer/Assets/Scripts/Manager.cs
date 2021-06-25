using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private List<GameObject> platforms;
    public GameObject player;
    public Transform spawn;
    public GameObject screenNextLevel;
    public GameObject screenGameOver;
    
    void Start()
    {
        player.transform.position = spawn.position;
      
    }

    public void ShowNextLevelScreen()
    {
        player.GetComponent<Player>().enabled = false;
        screenNextLevel.SetActive(true);
    }

    public void ShowGameOverSceen()
    {
        player.GetComponent<Player>().enabled = false;
        screenGameOver.SetActive(true);
    }
}
