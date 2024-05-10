using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// The button to start the game
public class PlayButton : MonoBehaviour
{
    public Button play_button;
    public Sprite normal;
    public Sprite click;
    // Start is called before the first frame update
    void Start()
    {
        play_button.image.sprite = normal;
        Button btn = play_button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        play_button.image.sprite = click;
        SceneManager.LoadScene("SampleScene");
    }
}
