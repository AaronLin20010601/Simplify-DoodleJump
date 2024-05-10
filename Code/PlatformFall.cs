using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The platform that can't stand on and will break
public class PlatformFall : MonoBehaviour
{
    public float timer = 0f;
    public bool collapse = false;
    public Transform target;
    public float lastframeY = 0f;
    public bool player_fallen = false;
    public SpriteRenderer spriteRenderer;
    public Sprite collapse_begin;
    public Sprite collapsing;
    public Sprite collapse_end;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player_fallen == true && collision.gameObject.CompareTag("Player"))
        {
            collapse = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (collapse == true)
        {
            timer += Time.deltaTime;
            if (timer < 0.05f)
            {
                spriteRenderer.sprite = collapse_begin;
            }
            else if (timer >= 0.05f && timer < 0.1f)
            {
                spriteRenderer.sprite = collapsing;
            }
            else
            {
                spriteRenderer.sprite = collapse_end;
            }
        }    
    }
    private void FixedUpdate()
    {
        if (target.position.y - lastframeY < 0)
        {
            player_fallen = true;
        }
        else
        {
            player_fallen = false;
        }
        lastframeY = target.position.y;
    }
}
