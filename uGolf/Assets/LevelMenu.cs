using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public AudioSource SFXAudioSource;
    public void OpenLevel(int levelNumber){
        string level = "Level" + levelNumber;
        SceneManager.LoadScene(level);
    }

    public void ButtonClicked(AudioClip clip){
        SFXAudioSource.PlayOneShot(clip);
    }
}
