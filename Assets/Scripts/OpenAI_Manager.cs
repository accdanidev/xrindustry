using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class OpenAI_Manager : MonoBehaviour
{

    // Replace this with your actual API key and endpoint URL
    [SerializeField]
    private string apiKey = "";
    [SerializeField]
    private string apiUrl = "https://looking-glass-azureopenai.openai.azure.com/openai/deployments/gpt-4o/chat/completions?api-version=2024-08-01-preview";
    
    
    static string userMessage = "";
    string payload = $"{{\n  \"messages\": [\n    {{\n      \"role\": \"user\",\n      \"content\": [\n        {{\n          \"type\": \"text\",\n          \"text\": \"{userMessage}\"\n        }}\n      ]\n    }}\n  ],\n  \"temperature\": 0.7,\n  \"top_p\": 0.95,\n  \"max_tokens\": 800\n}}";
    private string apiResponse;
    public string responseBoard, response;
    public bool bl = false;
    public int pp = 0;

    // Start is called before the first frame update
    void Start()
    {
        
       // CallModel("Hi this is Karo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Board
    public void CallModelBoard(string prompt)
    {        
        userMessage = prompt;
        StartApiRequest(OnApiResponseBoard);        
    }


    // Start the API request with a callback
    public void StartApiRequestBoard(System.Action<string> callback)
    {
        StartCoroutine(SendRequestBoard(callback));
    }

    private IEnumerator SendRequestBoard(System.Action<string> callback)
    {
        string payload = $"{{\n  \"messages\": [\n    {{\n      \"role\": \"user\",\n      \"content\": [\n        {{\n          \"type\": \"text\",\n          \"text\": \"{userMessage}\"\n        }}\n      ]\n    }}\n  ],\n  \"temperature\": 0.7,\n  \"top_p\": 0.95,\n  \"max_tokens\": 800\n}}";

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(payload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("api-key", apiKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            apiResponse = request.downloadHandler.text;
            Debug.Log("Response: " + apiResponse);
        }
        else
        {
            apiResponse = "Error: " + request.error;
            Debug.LogError(apiResponse);
        }

        // Call the callback with the response
        callback(apiResponse);
    }

     private void OnApiResponseBoard(string apiResponse)
    {
        Debug.Log("Received API Response: " + apiResponse);
        ApiResponse response_obj = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);
        // Asigna el contenido de la respuesta a la variable de instancia 'response'
        responseBoard = response_obj.choices[0].message.content;
        Debug.Log(responseBoard);
    }

    #endregion

    #region Questions
    public void CallModelQuestions(string prompt)
    {
        userMessage = prompt;
        StartApiRequest(OnApiResponse);
    }

    public void StartApiRequest(System.Action<string> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(System.Action<string> callback)
    {
        string payload = $"{{\n  \"messages\": [\n    {{\n      \"role\": \"user\",\n      \"content\": [\n        {{\n          \"type\": \"text\",\n          \"text\": \"{userMessage}\"\n        }}\n      ]\n    }}\n  ],\n  \"temperature\": 0.7,\n  \"top_p\": 0.95,\n  \"max_tokens\": 800\n}}";

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(payload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("api-key", apiKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            apiResponse = request.downloadHandler.text;
            Debug.Log("Response: " + apiResponse);
        }
        else
        {
            apiResponse = "Error: " + request.error;
            Debug.LogError(apiResponse);
        }

        // Call the callback with the response
        callback(apiResponse);
    }

    private void OnApiResponse(string apiResponse)
    {
        Debug.Log("Received API Response: " + apiResponse);
        ApiResponse response_obj = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);
        // Asigna el contenido de la respuesta a la variable de instancia 'response'
        response = response_obj.choices[0].message.content;
        //Debug.Log(response);
    }
    #endregion

}

public class Hate
{
    public bool filtered { get; set; }
    public string severity { get; set; }
}

public class ProtectedMaterial
{
    public bool filtered { get; set; }
    public bool detected { get; set; }
}

public class SelfHarm
{
    public bool filtered { get; set; }
    public string severity { get; set; }
}

public class Sexual
{
    public bool filtered { get; set; }
    public string severity { get; set; }
}

public class Violence
{
    public bool filtered { get; set; }
    public string severity { get; set; }
}

public class ContentFilterResults
{
    public Hate hate { get; set; }
    public ProtectedMaterial protected_material_code { get; set; }
    public ProtectedMaterial protected_material_text { get; set; }
    public SelfHarm self_harm { get; set; }
    public Sexual sexual { get; set; }
    public Violence violence { get; set; }
}

public class Message
{
    public string content { get; set; }
    public string role { get; set; }
}

public class Choice
{
    public ContentFilterResults content_filter_results { get; set; }
    public string finish_reason { get; set; }
    public int index { get; set; }
    public object logprobs { get; set; }
    public Message message { get; set; }
}

public class PromptFilterResult
{
    public int prompt_index { get; set; }
    public ContentFilterResults content_filter_results { get; set; }
}

public class Usage
{
    public int completion_tokens { get; set; }
    public int prompt_tokens { get; set; }
    public int total_tokens { get; set; }
}

public class ApiResponse
{
    public List<Choice> choices { get; set; }
    public long created { get; set; }
    public string id { get; set; }
    public string model { get; set; }
    public string @object { get; set; }
    public List<PromptFilterResult> prompt_filter_results { get; set; }
    public string system_fingerprint { get; set; }
    public Usage usage { get; set; }
}
