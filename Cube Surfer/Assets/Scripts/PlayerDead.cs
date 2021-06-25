using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Platform")
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().ShowGameOverSceen();
        }
    }
}
