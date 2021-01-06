using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Game : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDisplay;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
            playerDisplay.text = "Player: " + DBManager.username;
            scoreDisplay.text = "Score: " + DBManager.score;
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/reg/savedata.php", form))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("ERROR" + webRequest.error);
                    break;
                
                case UnityWebRequest.Result.Success:

                    if (webRequest.downloadHandler.text == "0")
                    {
                        Debug.Log("GAME SAVED");
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                        break;

                    } else {
                        Debug.Log("SAVE FAILED. ERROR:" + webRequest.downloadHandler.text + "END");
                        break;
                    }
                  
            }

        }


    }


    public void IncreaseScore()
    {
        DBManager.score++;
        scoreDisplay.text = "Score: " + DBManager.score;
    }
   
}
