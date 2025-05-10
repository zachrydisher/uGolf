using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource SFXAudioSource;
    public void QuitGame(){
        Debug.Log("Quit!!");
        Application.Quit();
    }

    public void ButtonClicked(AudioClip clip){
        SFXAudioSource.PlayOneShot(clip);
    }
}
