using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider; // R�f�rence au curseur de volume dans l'interface utilisateur
    public AudioSource audioSource; // R�f�rence � la source audio que vous souhaitez contr�ler

    void Start()
    {
        // Assurez-vous que le curseur de volume est initialis� � la valeur actuelle du volume
        volumeSlider.value = audioSource.volume;
    }

    // M�thode appel�e lorsque la valeur du curseur de volume change
    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Mettre � jour le volume de la source audio
    }
}
