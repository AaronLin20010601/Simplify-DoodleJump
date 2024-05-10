using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// The button back to menu
public class MenuButton : MonoBehaviour
{
    public Button menu_button;
    public Sprite normal;
    public Sprite click;
    // Start is called before the first frame update
    void Start()
    {
        menu_button.image.sprite = normal;
        Button btn = menu_button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        menu_button.image.sprite = click;
        SceneManager.LoadScene("Menu");
    }
}
