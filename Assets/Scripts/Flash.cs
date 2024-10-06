using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public CanvasGroup whiteImage;
    public float flashSpeed = 0.1f;

    void Start()
    {
        whiteImage.alpha = 0;
    }

    [ContextMenu("Flash Screen")]
    public void FlashScreen()
    {
        StartCoroutine(FlashScreenCoroutine());
    }

    private IEnumerator FlashScreenCoroutine()
    {
        whiteImage.alpha = 1;
        yield return new WaitForSeconds(flashSpeed);
        whiteImage.alpha = 0;
    }
}
