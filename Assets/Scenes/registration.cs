using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Dropdown countryField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("country", countryField.value);

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/reg/register.php", form))
        {
            yield return webRequest.SendWebRequest();
            // Lets check what PHP sent back
           // Debug.Log("RESPONSE: " + (webRequest.downloadHandler.text.Split('\t')[0]) + " ) ");
            Debug.Log("RESPONSE: " + webRequest.downloadHandler.text + " ) ");

            if ((webRequest.downloadHandler.text.Split('\t')[0]) == "0")
            {
                Debug.Log("REGISTER SUCCESS: " + webRequest.downloadHandler.text + " )");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);

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

    public void LogCountry()
    {
        Debug.Log(countryField.value);
    }
}

