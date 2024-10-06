using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public float maxTime = 1.5f;
    public float HeightRange = 0.5f;
    public GameObject pipe;

    private float timer;

    private void Start()
    {
        SpawnPipe();


    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;

    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0,Random.Range(-HeightRange, HeightRange));
        GameObject pipeObj = Instantiate(pipe, spawnPos, Quaternion.identity);

        Destroy(pipeObj, 10f);

    }
}
