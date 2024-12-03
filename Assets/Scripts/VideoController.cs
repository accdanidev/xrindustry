using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    bool isFF, isRW;
    public Animator animatorVideo;

    // Start is called before the first frame update
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RWVideoButton();
        }
        if (Input.GetKey(KeyCode.W))
        {
            PlayVideoButton();
        }
        if (Input.GetKey(KeyCode.E))
        {
            PauseVideoButton();
        }
        if (Input.GetKey(KeyCode.R))
        {
            FFVideoButton();
        }
    }

    public void PlayVideoButton()
    {
        if (isFF || isRW)
        {
            videoPlayer.playbackSpeed = 1.0f;
            isFF = false;
            isRW = false;
        }

        videoPlayer.Play();
    }

    public void PauseVideoButton()
    {
        if (isFF || isRW)
        {
            videoPlayer.playbackSpeed = 1.0f;
            isFF = false;
            isRW = false;
        }
        videoPlayer.Pause();
    }

    public void FFVideoButton()
    {
        videoPlayer.playbackSpeed = 4.0f;
        isFF = true;
    }

    public void RWVideoButton()
    {
        isRW = true;
        videoPlayer.playbackSpeed = -2.0f;
    }

    public void PlayVideoAnimator()
    {
        animatorVideo.SetTrigger("Play");
    }

}
