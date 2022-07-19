using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject[] enemy;
    public float time;


    void Start()
    {
        StartCoroutine("Spawn");
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(time);

        int posIndex = Random.Range(0, pos.Length);
        int enemyIndex = Random.Range(0, enemy.Length);
        //Debug.Log(posIndex);
        //Debug.Log(enemyIndex);

        Vector3 temp = pos[posIndex].transform.localScale;
        //Debug.Log(temp);

        Vector3 spawnPos = Vector3.zero;
        spawnPos.x = Random.Range(-temp.x / 2, temp.x / 2);
        spawnPos.y = Random.Range(-temp.y / 2, temp.y / 2);
        spawnPos += pos[posIndex].transform.position;
        //Debug.Log(spawnPos);

        Instantiate(enemy[enemyIndex], spawnPos, Quaternion.identity);
        
        StartCoroutine("Spawn");
    }

}
