using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float Duration;
    [SerializeField] private float Amount;
    [SerializeField] private bool Shaking = false;
    
    public void Shake()
    {
        StartCoroutine(ShakeCam2D());
    }

    private IEnumerator ShakeCam2D()
    {
        if (Shaking)
        {
            yield return null;
        }
        Shaking = true;
        Vector3 OriginalPos = transform.localPosition;

        float Elapsed = 0.0f;

        while (Elapsed < Duration)
        {
            float X = Random.Range(-1f, 1f) * Amount;
            float Y = Random.Range(-1f, 1f) * Amount;

            transform.position = new Vector3(X, Y, OriginalPos.z);

            Elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = OriginalPos;
        Shaking = false;
    }
}
