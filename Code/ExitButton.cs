using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The button to exit the gmae
public class ExitButton : MonoBehaviour
{
    public Button exit_button;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = exit_button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        Application.Quit();
    }
}
