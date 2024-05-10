using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// The scoreboard of the game which count the score based on how high position the player get
public class ScoreBoard : MonoBehaviour
{
    public int score;
    public Transform target;
    public TextMeshProUGUI showscore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    private void LateUpdate()
    {
        if (target.position.y + 4.2f > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y + 4.2f, transform.position.z);
            transform.position = newPosition;
        }
    }
    // Update is called once per frame
    void Update()
    {      
        if ((int)target.position.y > score)
        {
            score = (int)target.position.y;
        }
        showscore.text = "score : " + score.ToString();
    }
}
