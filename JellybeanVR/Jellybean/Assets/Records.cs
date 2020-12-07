using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Records
{
    public struct Entry
    {
        public Vector3 rotation;
        public bool input;
        public float time;
        public string currentScene;
    }

    public static Records instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Records();
            }

            return _instance;
        }
    }

    private static Records _instance;

    private List<Entry> currentSessionRecording;

    private Records()
    {
        currentSessionRecording = new List<Entry>();
    }

    public static void AddEntry(Vector3 rotation, bool input, string sceneName)
    {
        var newEntry = new Entry { rotation = rotation, input = input, time = Time.time, currentScene = sceneName };
        //instance.currentSessionRecording.Add(newEntry);
        WebAPI.LogInput(newEntry);
    }
}