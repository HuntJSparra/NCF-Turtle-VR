using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
//using System.Net.Http.Json;
using UnityEngine;

public static class WebAPI {
    static readonly HttpClient httpClient = new HttpClient();
    static readonly string API_URL = "http://www.hjsparra.com/api/jellybean";

    public static async void LogLevelStart(string sceneName)
    {
        Debug.Log("Logging level start");
        try
        {
            string json = "{" +
                "\"UserId\": 1," +
                "\"SessionId\": 2," +
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

    public static async void LogReading(string textNickname, float duration)
    {
        Debug.Log("Logging reading duration");
        try
        {
            string json = "{" +
                "\"UserId\": 1," +
                "\"SessionId\": 2," +
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

    public static async void LogInput(Records.Entry entry)
    {
        Debug.Log("Logging input");
        try
        {
            var entryAsString = entry.time + ", "
                                + entry.currentScene.ToString() + ", "
                                + entry.rotation.ToString() + ", "
                                + entry.input.ToString();

            string json = "{" +
                "\"UserId\": 1," +
                "\"SessionId\": 2," +
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
