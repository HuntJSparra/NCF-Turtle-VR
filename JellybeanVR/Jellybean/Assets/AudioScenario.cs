using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScenario : MonoBehaviour
{
    public static AudioScenario instance;

    public AudioEvent[] audioEvents;
    private Dictionary<string, AudioEvent> audioEventsDictionary = new Dictionary<string, AudioEvent>();

    [System.Serializable]
    public struct AudioEvent {
        public string tag;
        public AudioSource audioSource;
        public float playbackDelay;
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (AudioEvent audioEvent in audioEvents)
        {
            audioEventsDictionary.Add(audioEvent.tag, audioEvent);
        }
    }

    public bool TriggerAudioEvent(string tag)
    {
        if (!audioEventsDictionary.ContainsKey(tag))
        {
            return false;
        }

        var audioEvent = audioEventsDictionary[tag];
        audioEvent.audioSource.PlayDelayed(audioEvent.playbackDelay);

        return true;
    }
}
