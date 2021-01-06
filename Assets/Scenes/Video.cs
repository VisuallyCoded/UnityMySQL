using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Video : MonoBehaviour
{
    public Button loadVideo;

    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 0.5F;
        //videoPlayer.url = "file://C:/Users/SethHarden/Desktop/TheS4Shoe.mp4";
        videoPlayer.url = "https://sethharden.com/video/vid02.mp4";
        videoPlayer.frame = 100;
        videoPlayer.isLooping = true;
       // videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }
}