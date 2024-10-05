using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public float MaxTime = 1.5f;
    public float HeighRange = 0.5f;
    public GameObject Pipe;

    private float Timer;

    private void Start()
    {
        SpawnPipe();


    }

    private void Update()
    {
        if (Timer > MaxTime)
        {
            SpawnPipe();
            Timer = 0;
        }
        Timer += Time.deltaTime;

    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0,Random.Range(-HeighRange, HeighRange));
        GameObject pipe = Instantiate(Pipe, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);

    }
}
