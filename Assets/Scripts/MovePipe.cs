using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float Speed = 0.65f;
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
