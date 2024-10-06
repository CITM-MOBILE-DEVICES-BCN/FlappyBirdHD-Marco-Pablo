using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float Speed = 0.65f;
    private FlyBehaviour FlyBehaviour;

    private void Start()
    {
        FlyBehaviour = FindObjectOfType<FlyBehaviour>();
    }
    void Update()
    {
        if (!FlyBehaviour.Dead)
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
    }
}