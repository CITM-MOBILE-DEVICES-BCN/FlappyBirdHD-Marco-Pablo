using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float amount;
    [SerializeField] private bool shaking = false;
    
    public void Shake()
    {
        StartCoroutine(ShakeCam2D());
    }

    private IEnumerator ShakeCam2D()
    {
        if (shaking)
        {
            yield return null;
        }
        shaking = true;
        Vector3 originalPos = transform.localPosition;

        float Elapsed = 0.0f;

        while (Elapsed < duration)
        {
            float X = Random.Range(-1f, 1f) * amount;
            float Y = Random.Range(-1f, 1f) * amount;

            transform.position = new Vector3(X, Y, originalPos.z);

            Elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        shaking = false;
    }
}
