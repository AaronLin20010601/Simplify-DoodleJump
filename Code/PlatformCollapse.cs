using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The platform that slowly collapse and only can be use while it doesn't broke
public class PlatformCollapse : MonoBehaviour
{
    public float timer = 0f;
    public bool start_collapse = false;
    public Transform target;
    public float jumpForce = 10f;
    public EdgeCollider2D ec;
    public SpriteRenderer spriteRenderer;
    public Sprite collapsing1;
    public Sprite collapsing2;
    public Sprite collapsing3;
    public Sprite collapsing4;
    public Sprite collapse_end1;
    public Sprite collapse_end2;
    public Sprite collapse_end3;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ec = GetComponent<EdgeCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - target.position.y < 5f && transform.position.x < 2.75f)
        {
            start_collapse = true;
        }
        if (start_collapse == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1f && timer < 2f)
            {
                spriteRenderer.sprite = collapsing1;
            }
            else if (timer >= 2f && timer < 3f)
            {
                spriteRenderer.sprite = collapsing2;
            }
            else if (timer >= 3f && timer < 4f)
            {
                spriteRenderer.sprite = collapsing3;
            }
            else if (timer >= 4f && timer < 5f)
            {
                spriteRenderer.sprite = collapsing4;
            }
            else if (timer >= 5f && timer < 5.1f)
            {
                ec.enabled = false;
                spriteRenderer.sprite = collapse_end1;
            }
            else if (timer >= 5.1f && timer < 5.2f)
            {
                spriteRenderer.sprite = collapse_end2;
            }
            else if (timer >= 5.2f && timer < 5.3f)
            {
                spriteRenderer.sprite = collapse_end3;
            }
        }
    }
}
