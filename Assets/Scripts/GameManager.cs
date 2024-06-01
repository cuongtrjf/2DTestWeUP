using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
    
public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject completeScreen;

    private void Awake()
    {
        EnemyHealth.onEnemyDie += UpdateScore;
        Score.onComplete += ActiveCompleteScreen;
    }

    private void Start()
    {
        completeScreen.SetActive(false);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + Score.GetScore();
    }

    void ActiveCompleteScreen()
    {
        StartCoroutine(SetActiveCompleteScreen());
    }

    IEnumerator SetActiveCompleteScreen()
    {
        yield return new WaitForSeconds(1f);
        MusicManager.StopBackgroundMusic();
        completeScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        MusicManager.PlayerBackgroundMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
