using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : StackingObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            Debug.Log("Victory");
            bricks.Clear();   
            
        }
    }
}
