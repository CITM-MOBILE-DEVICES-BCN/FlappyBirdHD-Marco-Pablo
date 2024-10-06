using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FlyBehaviour : MonoBehaviour
{
    [Header("References")]
    public GameObject PipeSpawner;
    public GameObject Score;
    public GameObject TapIcon;
    public Collider2D BirdCollider;
    public Flash Flash;
    public CameraShake CameraShake;
    public LoopGround LoopGround;

    [Header("Variables")]
    [SerializeField] private float Velocity = 1.5f;
    [SerializeField] private float Gravity = 1.0f;
    [SerializeField] private float LittleCoolDown = 0.1f;

    private Rigidbody2D Rb;

    private bool StartFlying = true;
    public bool Dead = false;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        LittleCoolDown = 0.0f;
        Rb.gravityScale = 0;
        PipeSpawner.SetActive(false);
        TapIcon.SetActive(true);
        Score.SetActive(false);
        AudioManager.instance.PlayMusic("Theme");
    }

    void Update()
    {
        if (!StartFlying)
        {
            Rb.velocity -= -Gravity * Time.deltaTime * Vector2.down;
            TapIcon.SetActive(false);
            PipeSpawner.SetActive(true);
            Score.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && !Dead)
        {
            AudioManager.instance.PlaySFX("Fly");
            
            if (LittleCoolDown <= 0)
            {
                Rb.velocity = Vector2.up * Velocity;
                StartFlying = false;
                LittleCoolDown = 0.1f;
            }
        }

        LittleCoolDown -= Time.deltaTime;

        if (Rb.velocity.y > 0)
        {
            float DesiredAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, 27, 3.5f);
            transform.rotation = Quaternion.Euler(0, 0, DesiredAngle);
        }
        else
        {
            float DesiredAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, -90, -Rb.velocity.y/7);
            transform.rotation = Quaternion.Euler(0, 0, DesiredAngle);
        }

        Mathf.Clamp(transform.rotation.z, -90, 27);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead = true;

        BirdCollider.enabled = false;

        Rb.velocity = Vector2.zero;
        Rb.AddForce(Vector2.up * 0.3f, ForceMode2D.Impulse);
        Rb.AddForce(Vector2.right * 0.2f, ForceMode2D.Impulse);

        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.3f, 1.3f, 1.3f), 0.2f);

        Flash.FlashScreen();
        CameraShake.Shake();
        LoopGround.Stop();
        PipeSpawner.SetActive(false);

        AudioManager.instance.PlaySFX("Hit");
        
        Invoke(nameof(Restart), 1.0f);
    }

    private void Restart()
    {        
        GameManager.Instance.GameOver();
    }
}
