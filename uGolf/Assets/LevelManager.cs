using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip hittingBall;
    public AudioClip ballInHole;
    public AudioClip levelWin;
    public AudioClip levelLose;
    public AudioSource SFXSource1;
    public AudioSource SFXSource2;
    public TextMeshProUGUI strokesLeftText;
    private int levelNum;
    public int[] maxStrokesPerLevel = {3,4,5};
    public int strokesLeft;
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;
        strokesLeft = maxStrokesPerLevel[levelNum-1];
        SetStrokesLeft(strokesLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void WinHole()
        {
            SFXSource1.clip = ballInHole;
            SFXSource1.Play();
            SFXSource2.clip = levelWin;
            SFXSource2.Play();
            //strokesLeft = 

            //TODO: WIN LEVEL POP UP UI
            winScreen.SetActive(true);

        }

    public void PlayGolfHit()
    {
        SFXSource1.clip = hittingBall;
        SFXSource1.Play();
        
    }

    public void SetStrokesLeft(int numStrokes){
        strokesLeftText.text = "Strokes Left: " + numStrokes;

        if(numStrokes == 0){
            LoseHole();
        }
    }

    public void LoseHole(){
        SFXSource1.clip = levelLose;
        SFXSource1.Play();
        loseScreen.SetActive(true);
    }
}
