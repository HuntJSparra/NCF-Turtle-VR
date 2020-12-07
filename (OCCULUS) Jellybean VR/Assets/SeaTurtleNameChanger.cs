using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeaTurtleNameChanger : MonoBehaviour
{
    public Text nameField;
    public string seaTurtleName = "Jellybean";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void EnterName()
    {
        seaTurtleName = nameField.text;
        SceneManager.LoadScene("Base");
    }
}
