using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
//using System.Net.Http.Json;
using UnityEngine;


public class WebAPI {
    readonly HttpClient httpClient;
    readonly string API_URL = "http://localhost:5000/api/jellybean";//"http://www.hjsparra.com/api/jellybean";

    private bool initialized;
    private int userId, sessionNum;
    public static WebAPI instance
    {
        get
        {
            if (_instance == null)
            {
                instance = new WebAPI();
            }

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    private static WebAPI _instance;

    public WebAPI()
    {
        httpClient = new HttpClient();
        initialized = false;
        Initialize();
    }

    public async void Initialize()
    {
        // DEBUG ONLY
        //PlayerPrefs.DeleteKey("userId");
        //PlayerPrefs.DeleteKey("sessionNum");
        // END DEBUG ONLY

        if (initialized)
        {
            Debug.LogWarning("WebAPI(instance).Initialize called multiple times");
            return;
        }

        try
        {
            var response = await httpClient.GetAsync(API_URL);
            response.EnsureSuccessStatusCode();

            if (PlayerPrefs.HasKey("userId"))
            {
                userId = PlayerPrefs.GetInt("userId", -1);
            }
            else
            {
                int newId;
                HttpResponseMessage idTakenResponse;
                do
                {
                    Debug.Log("Generating new User ID...");
                    newId = UnityEngine.Random.Range(0, Int32.MaxValue);
                    idTakenResponse = await httpClient.GetAsync(API_URL + "/" + newId); // Should this be in a try-catch?
                } while (idTakenResponse.IsSuccessStatusCode); // Success means it is taken
                userId = newId;
                Debug.Log("Generated available User ID");
            }
            PlayerPrefs.SetInt("userId", userId);

            sessionNum = PlayerPrefs.GetInt("sessionNum", 1);
            PlayerPrefs.SetInt("sessionNum", sessionNum + 1);
            PlayerPrefs.Save(); // USED FOR STORING BOTH ID AND SESSION #

            Debug.Log(string.Format("Initialized WebAPI with\n\tUser ID: {0}, Session #{1}", userId, sessionNum));

            initialized = true;
        }
        catch (HttpRequestException e)
        {
            Debug.LogError("Unable to connect to API: " + e.Message);
            // initialized is still false!
        }
    }


    public static void LogLevelStart(string sceneName)
    {
        if (!instance.initialized)
        {
            Debug.LogError("WebAPI Helper not initialized");
        }
        else
        {
            instance._LogLevelStart(sceneName);
        }
    }

    private async void _LogLevelStart(string sceneName)
    {
        Debug.Log("Logging level start");
        try
        {
            string json = "{" +
                "\"UserId\": "+userId+"," +
                "\"SessionId\": "+sessionNum+"," +
                "\"Type\": \"Scene Loaded\"," +
                "\"Data\": \"" + sceneName + "\"" +
                "}";
            var content = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await httpClient.PostAsync(API_URL, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log(responseBody);
        }
        catch (HttpRequestException e)
        {
            Debug.Log("HTTP Exception: "+e.Message);
        }
    }


    public static void LogReading(string textNickname, float duration)
    {
        if (!instance.initialized)
        {
            Debug.LogError("WebAPI Helper not initialized");
        }
        else
        {
            instance._LogReading(textNickname, duration);
        }
    }

    private async void _LogReading(string textNickname, float duration)
    {
        Debug.Log("Logging reading duration");
        try
        {
            string json = "{" +
                "\"UserId\": " + userId + "," +
                "\"SessionId\": " + sessionNum + "," +
                "\"Type\": \"Reading Duration\"," +
                "\"Data\": \"" + textNickname + ", " + duration + "\"" +
                "}";
            var content = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await httpClient.PostAsync(API_URL, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log(responseBody);
        }
        catch (HttpRequestException e)
        {
            Debug.Log("HTTP Exception: " + e.Message);
        }
    }


    public static void LogInput(Records.Entry entry)
    {
        if (!instance.initialized)
        {
            Debug.LogError("WebAPI Helper not initialized");
        }
        else
        {
            instance._LogInput(entry);
        }
    }

    public async void _LogInput(Records.Entry entry)
    {
        Debug.Log("Logging input");
        try
        {
            var entryAsString = entry.time + ", "
                                + entry.currentScene.ToString() + ", "
                                + entry.rotation.ToString() + ", "
                                + entry.input.ToString();

            string json = "{" +
                "\"UserId\": " + userId + "," +
                "\"SessionId\": " + sessionNum + "," +
                "\"Type\": \"Input\"," +
                "\"Data\": \"" + entryAsString + "\"" +
                "}";
            var content = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await httpClient.PostAsync(API_URL, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log(responseBody);
        }
        catch (HttpRequestException e)
        {
            Debug.Log("HTTP Exception: " + e.Message);
        }
    }
}
