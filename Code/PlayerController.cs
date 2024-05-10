using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The player control and state, sprite changes part
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private float moveX;
    public SpriteRenderer spriteRenderer;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public int state = 0;
    public float timer = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemEffect();
        // Keyboard input
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        if (moveX < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else if (moveX > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        // Keyboard movement
        velocity.x = moveX;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hat") && state == 0)
        {
            state = 1;
        }
        if (collision.gameObject.CompareTag("Rocket") && state == 0)
        {
            state = 2;
        }
        if (collision.gameObject.CompareTag("Monster") && state == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // The effect activate after player get the item
    public void ItemEffect()
    {
        if (state == 1)
        {
            timer += Time.deltaTime;
            rb.Sleep();
            transform.tag = "HatActivePlayer";
            transform.position += new Vector3(0, 10f, 0) * Time.deltaTime;
            if (timer >= 5f)
            {
                timer = 0f;
                state = 0;
                rb.WakeUp();
                transform.tag = "Player";
            }
        }
        else if (state == 2)
        {
            timer += Time.deltaTime;
            rb.Sleep();
            transform.tag = "RocketActivePlayer";
            transform.position += new Vector3(0, 20f, 0) * Time.deltaTime;
            if (timer >= 5f)
            {
                timer = 0f;
                state = 0;
                rb.WakeUp();
                transform.tag = "Player";
            }
        }
    }
}
