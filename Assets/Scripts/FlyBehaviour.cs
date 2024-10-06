using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FlyBehaviour : MonoBehaviour
{
    [Header("References")]
    public GameObject pipeSpawner;
    public GameObject score;
    public GameObject TapIcon;
    public Collider2D bridCollider;
    public Flash flash;
    public CameraShake cameraShake;
    public LoopGround loopGround;

    [Header("Variables")]
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float gravity = 1.0f;
    [SerializeField] private float littleCooldown = 0.1f;

    private Rigidbody2D rb;

    private bool startFly = true;
    public bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        littleCooldown = 0.0f;
        rb.gravityScale = 0;
        pipeSpawner.SetActive(false);
        TapIcon.SetActive(true);
        score.SetActive(false);
        AudioManager.instance.PlayMusic("Theme");
    }

    void Update()
    {
        if (!startFly)
        {
            rb.velocity -= -gravity * Time.deltaTime * Vector2.down;
            TapIcon.SetActive(false);
            pipeSpawner.SetActive(true);
            score.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && !dead)
        {
            AudioManager.instance.PlaySFX("Fly");
            
            if (littleCooldown <= 0)
            {
                rb.velocity = Vector2.up * velocity;
                startFly = false;
                littleCooldown = 0.1f;
            }
        }

        littleCooldown -= Time.deltaTime;

        if (rb.velocity.y > 0)
        {
            float desiredAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, 27, 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, desiredAngle);
        }
        else if (rb.velocity.y < 0)
        {
            float desiredAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, -90, Time.deltaTime * 3.5f);
            transform.rotation = Quaternion.Euler(0, 0, desiredAngle);
        }

        Mathf.Clamp(transform.rotation.z, -90, 27);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dead = true;

        bridCollider.enabled = false;

        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 0.3f, ForceMode2D.Impulse);
        rb.AddForce(Vector2.right * 0.2f, ForceMode2D.Impulse);

        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.3f, 1.3f, 1.3f), 0.2f);

        flash.FlashScreen();
        cameraShake.Shake();
        loopGround.Stop();
        pipeSpawner.SetActive(false);

        AudioManager.instance.PlaySFX("Hit");
        
        Invoke(nameof(Restart), 0.3f);
    }

    private void Restart()
    {        
        GameManager.instance.GameOver();
    }
}
