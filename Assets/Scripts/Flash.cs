using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public CanvasGroup WhiteImage;
    public float flashSpeed = 0.1f;

    void Start()
    {
        WhiteImage.alpha = 0;
    }

    [ContextMenu("Flash Screen")]
    public void FlashScreen()
    {
        StartCoroutine(FlashScreenCoroutine());
    }

    private IEnumerator FlashScreenCoroutine()
    {
        WhiteImage.alpha = 1;
        yield return new WaitForSeconds(flashSpeed);
        WhiteImage.alpha = 0;
    }
}
