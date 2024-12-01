using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeBrick : MonoBehaviour
{
    public GameObject objectToActivate; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            objectToActivate.SetActive(true);
        }
    }
}


