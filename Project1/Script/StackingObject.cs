using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackingObject : MonoBehaviour
{
    [SerializeField] public Transform playerVisual;
    [SerializeField]  private GameObject BrickPrefabs;
    [SerializeField] private Transform brickListParent;
    public List<GameObject> bricks = new List<GameObject>();

    public void AddBrick(GameObject brick)
    {
        bricks.Add(brick);  //them 1 gach moi trong list

        playerVisual.transform.position += Vector3.up * 2f;

        brick.transform.localPosition = Vector3.up * 2f * (bricks.Count - 1);
    }

    public void RemoveBrick()   
    {
        if (bricks.Count > 0)
        {
            playerVisual.transform.position -= Vector3.up * 2f;
            GameObject removeBrick = bricks[bricks.Count - 1];
            bricks.RemoveAt(bricks.Count - 1);
            Destroy(removeBrick);
        }
        //xu ly hinh anh
        //bricks.Remove(brick);   
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stackable"))
        {
            Destroy(other.gameObject);

            GameObject newBrick = Instantiate(BrickPrefabs, brickListParent);

            AddBrick(newBrick); 
        }

        if ( other.CompareTag("BridgeLayer"))
        {
            if (bricks.Count > 0)
            {
                RemoveBrick();
                other.tag = "Untagged";
                other.GetComponent<BridgeBrick>();
            }
        }
    }
}

