using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager 
{

    public static string username;
    public static int score;


    public static string video1url;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
