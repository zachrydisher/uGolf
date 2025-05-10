using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AUDIO SOURCE:")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AUDIO CLIPS:")]
    public AudioClip buttonPress;
}
