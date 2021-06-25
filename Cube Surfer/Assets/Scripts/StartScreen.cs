using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public Player playerScript;

    private void Start()
    {
        playerScript.enabled = false;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            playerScript.enabled = true;
            Destroy(gameObject);
        }
    }
}
