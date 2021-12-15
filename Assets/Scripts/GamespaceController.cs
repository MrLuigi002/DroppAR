using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamespaceController : MonoBehaviour
{
    [SerializeField] private GameObject warning;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            warning.SetActive(true);

            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            warning.SetActive(false);

            Time.timeScale = 1;
        }
    }
}
