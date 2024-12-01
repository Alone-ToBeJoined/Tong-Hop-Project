using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStair : MonoBehaviour
{
    [SerializeField] ColorSO colorData;
    [SerializeField] ColorType brickStairColor;
    [SerializeField] MeshRenderer meshRenderer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("collided");
            if (brickStairColor != other.GetComponent<PlayerController>().PlayerColor)
            {
                //doi mau
                meshRenderer.material = colorData.GetMaterial(other.GetComponent<PlayerController>().PlayerColor);

                //giam gach

            }
        }
    }
}
