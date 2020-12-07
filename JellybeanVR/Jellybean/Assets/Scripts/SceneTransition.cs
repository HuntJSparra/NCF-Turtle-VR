using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;

    public static string nextScene;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        var image = transform.GetChild(0).GetComponent<Image>();
        var currentColor = image.color;
        image.color = new Color(currentColor.r, currentColor.g, currentColor.b, 255);

        FadeIntoScene();
    }

    public void FadeIntoScene()
    {
        // The animator does this through its default state
    }

    public void FadeOutOfScene()
    {
        GetComponent<Animator>().SetTrigger("FadeOutOfScene");
    }

    public void ChangeScene(string newScene)
    {
        nextScene = newScene;
        FadeOutOfScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
