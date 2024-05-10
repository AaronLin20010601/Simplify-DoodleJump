using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The sprite change effect when player get the rocket item
public class RocketItemEffect : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer spriteRenderer;
    public Sprite rocket_left_sprite;
    public Sprite rocket_right_sprite;
    public int state = 0;
    private float detect_moveX;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
            spriteRenderer.sprite = rocket_right_sprite;
            transform.position = new Vector3(target.position.x + 0.4f, target.position.y - 0.1f, target.position.z);
        }
        else if (target.tag == "RocketActivePlayer" && state == 1)
        {
            spriteRenderer.sprite = rocket_left_sprite;
            transform.position = new Vector3(target.position.x - 0.4f, target.position.y - 0.1f, target.position.z);
        }
        else
        {
            transform.position = new Vector3(0, -8f, 0);
        }
    }
}
