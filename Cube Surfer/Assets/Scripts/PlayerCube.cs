using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCube : MonoBehaviour
{
    public GameObject cube;
    public GameObject playerWithCubes;
    public TextMeshProUGUI counterTxt;
    [SerializeField] private int valueCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            transform.SetParent(null);
        }
        if (other.gameObject.tag == "CubePlatform")
        {
            Destroy(other.gameObject);
            playerWithCubes.transform.localPosition = new Vector3(playerWithCubes.transform.localPosition.x,
                playerWithCubes.transform.localPosition.y + 0.33f,
                playerWithCubes.transform.localPosition.z);
            GameObject tmp = Instantiate(cube, new Vector3(transform.position.x, transform.position.y - 0.33f, transform.position.z), Quaternion.identity);
            tmp.transform.SetParent(playerWithCubes.transform);
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            int tmp;
            int.TryParse(counterTxt.text, out tmp);
            tmp += valueCoin;
            counterTxt.text = tmp.ToString();
            
        }
        if (other.gameObject.tag == "Finish")
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().ShowNextLevelScreen();
        }

    }
}
