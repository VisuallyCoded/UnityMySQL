using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;



public class WebTest : MonoBehaviour
{
    /*
    IEnumerator Start()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/reg/webtest.php"))
        {
            yield return webRequest.SendWebRequest();

            string[] webResults = webRequest.downloadHandler.text.Split('\t');

            Debug.Log("<color=red>" + webResults[0] + "</color>");

            // THIS IS ONLY FOR AN INTEGER
            int webNumber = int.Parse(webResults[1]);
            webNumber *= 2;
            Debug.Log(webNumber);
        }
    }
    */
}



/*
public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/reg/webtest.php"))
        {
            yield return webRequest.SendWebRequest();

            string[] webResults = webRequest.downloadHandler.text.Split('\t');
            foreach (string s in webResults)
            {
                Debug.Log(s);
            }
        }
    }
}
*/
//------------------------------------------------------------------