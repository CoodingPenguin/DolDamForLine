using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PauseBtnManage : MonoBehaviour
{

    public GameObject pausePanel;

    public AudioClip btnClicked;
    public AudioClip startBgm;



    public void Resume()
    {
        SoundManager.instance.bgmSource.Play();
        SoundManager.instance.PlaySingleForBtn(btnClicked);
        GameManager.instance.gameState = GameManager.GameState.PLAYING;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        SoundManager.instance.PlaySingleForBtn(btnClicked);
        ShowRewardedAdRestart();

    }

    public void MainMenu()
    {
        SoundManager.instance.PlaySingleForBtn(btnClicked);
        SoundManager.instance.PlayBgm(startBgm, true);
        ShowRewardedAdMain();

    }


    public void ShowRewardedAdRestart()
    {
        if (Advertisement.IsReady("video"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultRestart };
            Advertisement.Show("video", options);
        }

    }

    private void HandleShowResultRestart(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
        SceneManager.LoadScene("Resources/scenes/GameScene");
        GameManager.instance.gameState = GameManager.GameState.PLAYING;
        pausePanel.SetActive(false);
        SoundManager.instance.bgmSource.Play();

    }

    public void ShowRewardedAdMain()
    {
        if (Advertisement.IsReady("video"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultMain };
            Advertisement.Show("video", options);
        }

    }

    private void HandleShowResultMain(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
        SceneManager.LoadScene("Resources/scenes/StartScene");
        pausePanel.SetActive(false);
    }
}
