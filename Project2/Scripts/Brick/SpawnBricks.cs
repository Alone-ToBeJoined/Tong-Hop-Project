using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    public GameObject brickPrefab;
    public Transform brickParent;
    public int row;
    public int col;
    public float spacing;

    private void OnEnable()
    {
        Spawn();
    }

    public void Spawn()
    {
        for(int i=0; i<row; i++)
        {
            for(int j=0; j<col; j++)
            {
                GameObject brick = Instantiate(brickPrefab, brickParent); /// sinh ra một viên gạch
                brick.transform.localPosition = new Vector3(i, 0, j) * spacing;/// setup thông số cho gạch
                brick.GetComponent<Brick>().OnInit();/// bắt viên gạch khởi tạo
                brick.GetComponent<Brick>().spawnBricks = this;
            }
        }
    }
    public void SpawnBrick(float time,Vector3 position)
    {
        StartCoroutine(WaitForSpawn(time, position));
    }

    IEnumerator WaitForSpawn(float time, Vector3 position)
    {
        /// code owr tren thi chay luon
        yield return new WaitForSeconds(time);
        ///code o duoi thi sau time giay moi chay
        GameObject brick = Instantiate(brickPrefab, brickParent); /// sinh ra một viên gạch
        brick.transform.localPosition = position;/// vi tri de sinh ra gach
        brick.GetComponent<Brick>().OnInit();/// bắt viên gạch khởi tạo
        brick.GetComponent<Brick>().spawnBricks = this;
    }
}
