using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;

    void Start()
    {
        // Charger le score enregistré ou initialiser à zéro s'il n'y en a pas
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreUI();
        scoreText.text = score.ToString() + " zenni";
    }

    public void IncrementScore(int points)
    {
        score += points;
        UpdateScoreUI();
        // Enregistrer le score à chaque modification
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void DecrementScore(int points)
    {
        score -= points;
        UpdateScoreUI();
        // Enregistrer le score à chaque modification
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString() + " zenni";
    }
}
