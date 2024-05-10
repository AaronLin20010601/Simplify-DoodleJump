using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The sprite change effect of the rocket's fire when player get the rocket item
public class RocketFireEffect : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer spriteRenderer;
    public Sprite rocket_fire_start;
    public Sprite rocket_fire_small;
    public Sprite rocket_fire_medium;
    public Sprite rocket_fire_large;
    public int state = 0;
    public float timer;
    public bool activate = false;
    private float detect_moveX;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }
        detect_moveX = Input.GetAxis("Horizontal") * 1f;
        if (detect_moveX < 0)
        {
            state = 0;
        }
        else if (detect_moveX > 0)
        {
            state = 1;
        }
        if (target.tag == "RocketActivePlayer" && state == 0)
        {
            activate = true;
            transform.position = new Vector3(target.position.x + 0.4f, target.position.y - 0.72f, target.position.z);
        }
        else if (target.tag == "RocketActivePlayer" && state == 1)
        {
            activate = true;
            transform.position = new Vector3(target.position.x - 0.4f, target.position.y - 0.72f, target.position.z);
        }
        else
        {
            activate = false;
            transform.position = new Vector3(0, -8.64f, 0);
        }
        if ((timer >= 0f && timer < 0.25f) || (timer >= 4.75f && timer < 5f))
        {
            spriteRenderer.sprite = rocket_fire_start;
        }
        else if ((timer >= 0.25f && timer < 0.5f) || (timer >= 4.5f && timer < 4.75f))
        {
            spriteRenderer.sprite = rocket_fire_small;
        }
        else if ((timer >= 0.5f && timer < 0.75f) || (timer >= 4.25f && timer < 4.5f))
        {
            spriteRenderer.sprite = rocket_fire_medium;
        }
        else if (timer >= 0.75f && timer < 4.25f)
        {
            spriteRenderer.sprite = rocket_fire_large;
        }
    }
}
