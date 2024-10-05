using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float Width = 6f;

    private SpriteRenderer SpriteRenderer;

    private Vector2 StartSize;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StartSize = new Vector2(SpriteRenderer.size.x, SpriteRenderer.size.y);
    }

    private void Update()
    {
        SpriteRenderer.size = new Vector2(SpriteRenderer.size.x+Speed*Time.deltaTime, SpriteRenderer.size.y);

        if(SpriteRenderer.size.x> Width)
        {
            SpriteRenderer.size= StartSize;
        }
    }
}
