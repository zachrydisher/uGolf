using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject strokesText;

    void Awake()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        strokesText.SetActive(false);
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
