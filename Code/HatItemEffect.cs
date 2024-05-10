using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The sprite change effect when player get the hat item
public class HatItemEffect : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer spriteRenderer;
    public Sprite hat_left_sprite;
    public Sprite hat_middle_sprite;
    public Sprite hat_right_sprite;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.tag == "HatActivePlayer")
        {
            transform.position = new Vector3(target.position.x, target.position.y + 0.45f, target.position.z);
            timer += Time.deltaTime;
            if (timer >= 0f && timer < 0.125f)
            {
                spriteRenderer.sprite = hat_left_sprite;
            }
            else if (timer >= 0.125f && timer < 0.25f)
            {
                spriteRenderer.sprite = hat_middle_sprite;
            }
            else if (timer >= 0.25f && timer < 0.375f)
            {
                spriteRenderer.sprite = hat_right_sprite;
            }
            else if (timer >= 0.375f && timer < 0.5f)
            {
                spriteRenderer.sprite = hat_middle_sprite;
            }
            else if (timer >= 0.5f)
            {
                timer = 0f;
            }
        }
        else
        {
            transform.position = new Vector3(0, -7.5f, 0);
            spriteRenderer.sprite = hat_left_sprite;
            timer = 0f;
        }
    }
}
