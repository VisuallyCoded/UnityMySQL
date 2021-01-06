using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// THIS IS FOR GET (GETTING INFOMRAT
/// </summary>
public class Web : MonoBehaviour
{
    void Start()
    {

        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/GetDate.php"))
        {
  
            yield return webRequest.SendWebRequest();



            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("ErrorZZ: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP ErrorZZ: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("YYReceived: " + webRequest.downloadHandler.text);
                    break;
            }


        }
    }
}