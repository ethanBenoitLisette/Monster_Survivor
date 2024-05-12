using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider; // Référence au curseur de volume dans l'interface utilisateur
    public AudioSource audioSource; // Référence à la source audio que vous souhaitez contrôler

    void Start()
    {
        // Assurez-vous que le curseur de volume est initialisé à la valeur actuelle du volume
        volumeSlider.value = audioSource.volume;
    }

    // Méthode appelée lorsque la valeur du curseur de volume change
    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Mettre à jour le volume de la source audio
    }
}
