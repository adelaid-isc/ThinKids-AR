using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
public class VideoController : MonoBehaviour
{
    #region PRIVATE_MEMBERS
    private VideoPlayer videoPlayer;

    #endregion //PRIVATE_MEMBERS

    #region PUBLIC_MEMBERS
    public Button m_PlayButton;
    public Button m_PauseButton;
    public RectTransform m_ProgressBar;

    #endregion //PRIVATE_MEMBERS

    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Setup Delegates
        videoPlayer.errorReceived += HandleVideoError;
        videoPlayer.started += HandleStartedEvent;
        videoPlayer.prepareCompleted += HandlePrepareCompleted;
        videoPlayer.seekCompleted += HandleSeekCompleted;
        videoPlayer.loopPointReached += HandleLoopPointReached;

        LogClipInfo();
    }
    void Update()
    {

        if (videoPlayer.isPlaying)
        {
            ShowPlayButton(false);
            ShowPauseButton(true);

            if (videoPlayer.frameCount < float.MaxValue)
            {
                float frame = (float)videoPlayer.frame;
                float count = (float)videoPlayer.frameCount;

                float progressPercentage = 0;

                if (count > 0)
                    progressPercentage = (frame / count) * 100.0f;

                if (m_ProgressBar != null)
                    m_ProgressBar.sizeDelta = new Vector2((float)progressPercentage, m_ProgressBar.sizeDelta.y);
            }

        }
        else
        {
            ShowPlayButton(true);
            ShowPauseButton(false);
        }
    }
    void OnApplicationPause(bool pause)
    {
        Debug.Log("OnApplicationPause(" + pause + ") called.");
        if (pause)
            Pause();
    }

    #endregion // MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS
    public void Play()
    {
        Debug.Log("Play Video");
        PauseAudio(false);
        videoPlayer.Play();
        ShowPlayButton(false);
        ShowPauseButton(true);
    }
    public void Pause()
    {
        if (videoPlayer)
        {
            Debug.Log("Pause Video");
            PauseAudio(true);
            videoPlayer.Pause();
            ShowPlayButton(true);
            ShowPauseButton(false);
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    private void PauseAudio(bool pause)
    {
        for (ushort trackNumber = 0; trackNumber < videoPlayer.audioTrackCount; ++trackNumber)
        {
            if (pause)
                videoPlayer.GetTargetAudioSource(trackNumber).Pause();
            else
                videoPlayer.GetTargetAudioSource(trackNumber).UnPause();
        }
    }
    private void ShowPlayButton(bool enable)
    {
        m_PlayButton.enabled = enable;
        m_PlayButton.GetComponent<Image>().enabled = enable;
    }
    private void ShowPauseButton(bool enable)
    {
        m_PauseButton.enabled = enable;
        m_PauseButton.GetComponent<Image>().enabled = enable;
    }
    private void LogClipInfo()
    {
        if (videoPlayer.clip != null)
        {
            string stats =
                "\nName: " + videoPlayer.clip.name +
                "\nAudioTracks: " + videoPlayer.clip.audioTrackCount +
                "\nFrames: " + videoPlayer.clip.frameCount +
                "\nFPS: " + videoPlayer.clip.frameRate +
                "\nHeight: " + videoPlayer.clip.height +
                "\nWidth: " + videoPlayer.clip.width +
                "\nLength: " + videoPlayer.clip.length +
                "\nPath: " + videoPlayer.clip.originalPath;

            Debug.Log(stats);
        }
    }

    #endregion // PRIVATE_METHODS

    #region DELEGATES
    void HandleVideoError(VideoPlayer video, string errorMsg)
    {
        Debug.LogError("Error: " + video.clip.name + "\nError Message: " + errorMsg);
    }
    void HandleStartedEvent(VideoPlayer video)
    {
        Debug.Log("Started: " + video.clip.name);
    }
    void HandlePrepareCompleted(VideoPlayer video)
    {
        Debug.Log("Prepare Completed: " + video.clip.name);
    }
    void HandleSeekCompleted(VideoPlayer video)
    {
        Debug.Log("Seek Completed: " + video.clip.name);
    }
    void HandleLoopPointReached(VideoPlayer video)
    {
        Debug.Log("Loop Point Reached: " + video.clip.name);

        ShowPlayButton(true);
        ShowPauseButton(false);
    }

    #endregion //DELEGATES

}
