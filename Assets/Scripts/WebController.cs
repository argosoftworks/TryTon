using UnityEngine;
using Newtonsoft.Json;
using System.Collections;
using NativeWebSocket;
using TMPro;


public class WebController : MonoBehaviour
{
    [SerializeField] GameObject AuthPanel;
    [SerializeField] GameObject MessagePanel;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private GameObject DebugPanel;
    private string request;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    public static string uniq;
    private string message;
    private string url = "";
    
    
    IncomingMessage incoming;
    WebSocket websocket;
    
    async void Start()
    {
        request = "check_auth";
        websocket = new WebSocket("wss://tryton26.su/game/wss");
        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };
        websocket.OnMessage += (bytes) =>
        {
            // getting the message as a string
            message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage! " + message);
            WriteMessage();

        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };
        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };
        await websocket.Connect();
    }
    private void GenerateID()
    {
        uniq = "";
        int charAmount = 32; 
        for (int i = 0; i < charAmount; i++)
        {
            uniq += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
        }
        url = "https://t.me/trytongameauthbot?start=" + uniq;
        Debug.Log(url);
        Application.OpenURL(url);
        
        

    }
    
    private void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
     
    }

    IEnumerator SendAuthMessage()
    {
            
            check_authData check_authData = new check_authData()
            {
                uniqKey = uniq,
            };

            check_auth check_auth = new check_auth()
            {
                method = "check_auth",
                data = new check_authData()
                {
                    uniqKey = uniq,
                },
            };
            string json = JsonConvert.SerializeObject(check_auth, Formatting.Indented);
            if (websocket.State == WebSocketState.Open)
            {
                websocket.SendText(json);
                
            }
            yield return new WaitForSeconds(0.5f);
            incoming = JsonConvert.DeserializeObject<IncomingMessage>(message);
            if (incoming.wait != "true")
            {
                Debug.Log("wait false");
                StartCoroutine("SendStartGameMessage");
            }
            else
            {
                Debug.Log("wait true");
                StartCoroutine("SendAuthMessage");
            }
        
    }

    IEnumerator SendStartGameMessage()
    {
        
        StartGameData startgamedata = new StartGameData()
        {
            platform = "android",
        };

        StartGame startgame = new StartGame()
        {
            authKey = incoming.gameEncKey,
            method = "startGame",
            data = new StartGameData()
            {
                platform = "android",
            },
        };
        string json = JsonConvert.SerializeObject(startgame, Formatting.Indented);
        if (websocket.State == WebSocketState.Open)
        {
            websocket.SendText(json);
        }
        yield return new WaitForSeconds(0.5f);
        incoming = JsonConvert.DeserializeObject<IncomingMessage>(message);
        if (incoming.game_id != null && incoming.games != "0" && incoming.no_trt == null) 
        {
            AuthPanel.SetActive(false);
        }
        else if (incoming.no_trt == "true")
        {
            AuthPanel.SetActive(false);
            MessagePanel.SetActive(true);
            _messageText.text = "Недостаточно TRT";
            websocket.Close();
        }
        else if (incoming.games == "0")
        {
            AuthPanel.SetActive(false);
            MessagePanel.SetActive(true);
            _messageText.text = "Нет игр";
            websocket.Close();
        }
        
        
    }
    private void WriteMessage()
    {
        textMeshProUGUI.text += "\n" + message + " " + "WS Status" + " " + websocket.State;
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }

    public void OpenURL()
    {
        GenerateID();
        
        StartCoroutine("SendAuthMessage");

    }
    public void ButtonOn()
    {
        if (!DebugPanel.activeSelf)
        {
            DebugPanel.SetActive(true);
        }
        else
        {
            DebugPanel.SetActive(false) ;
        }
        
    }
    

}

public class check_authData
{
    public string uniqKey { get; set; }
}

public class check_auth
{
    public string method { get; set; }
    public check_authData data { get; set; }
}
public class IncomingMessage
{
    public string method { get; set; }
    public string gameEncKey { get; set; }

    public string no_trt { get; set; }
    public string wait { get; set; }
    public string game_id { get; set; }
    public string games { get; set; }
    public string isFirstGame { get; set; }

}

public class StartGameData
{
    public string platform { get; set; }
}


public class StartGame
{
    public string authKey { get; set; }
    public string method { get; set; }
    public StartGameData data { get; set; }
}







