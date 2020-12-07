using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogOnLoad : MonoBehaviour
{
    //public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        WebAPI.LogLevelStart(SceneManager.GetActiveScene().name);
    }
}
