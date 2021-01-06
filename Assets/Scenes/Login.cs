using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;

    public void CallLogin() 
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/reg/login.php", form))
        {
            yield return webRequest.SendWebRequest();
            // Lets check what PHP sent back
            Debug.Log("RESPONSE: " + (webRequest.downloadHandler.text.Split('\t')[0]) + " ) ");

            if ((webRequest.downloadHandler.text.Split('\t')[0]) == "0")
            {
                if ((webRequest.downloadHandler.text.Split('\t')[0]) == "E")
                {
                    Debug.LogError("INVALID PASSWORD");
                }
                else
                {
                    Debug.Log("CONNECTED: " + webRequest.downloadHandler.text);

                    //Load Username
                    DBManager.username = nameField.text;
                    //Load Score
                    DBManager.score = int.Parse(webRequest.downloadHandler.text.Split('\t')[1]);
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }

            }
            else
            {
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("CONNECTION OR DATA ERROR: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError("HTTP PROTOCOL ERROR " + webRequest.error);
                        break;
                }
            }


        }

    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 2 && passwordField.text.Length >= 2);
    }


}
