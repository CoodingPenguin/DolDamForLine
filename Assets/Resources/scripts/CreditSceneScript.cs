using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneScript : MonoBehaviour {

    public AudioClip rightButtonSound;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SoundManager.instance.PlaySingleForBtn(rightButtonSound);
                SceneManager.LoadScene("Resources/scenes/DeveloperScene");
            }
        }
    }

    public void ChangeGameScene()
    {
        SoundManager.instance.PlaySingleForBtn(rightButtonSound);
        SceneManager.LoadScene("Resources/scenes/DeveloperScene");
    }

}
