using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public SnakeMotion SnakeMotion;
    public static int currentLevelIndex;
    public static int score = 0;
    public static int bestScore = 0;
    public Text currentLevelText;
    public Text NextLevelText;
    public Text bestScoreText;
    public Text scoreText;
    public AudioSource BGM;
    public AudioSource WinSound;
    public AudioSource LoseSound;
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public enum Status
    {
        Play,
        Win,
        Lose,
    }
    public Status CurrentStatus { get; private set; }
    private void Start()
    {
        BGM.Play();
        Time.timeScale = 1;
        bestScoreText.text = "BEST SCORE\n" + PlayerPrefs.GetInt("BestScore", 0);
    }
    private void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        NextLevelText.text = (currentLevelIndex + 1).ToString();
        scoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "BEST SCORE: " + bestScore.ToString();
    }
    public void SnakeWin() 
    {
        if (CurrentStatus != Status.Play) return;
        CurrentStatus = Status.Win;
        PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
        Debug.Log("You Win!");
        BGM.Stop();
        WinSound.Play();
        if (score > PlayerPrefs.GetInt("BastScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }
    public void SnakeDied() 
    {
        if (CurrentStatus != Status.Play) return;
        CurrentStatus = Status.Lose;
        score = 0;
        BGM.Stop();
        Debug.Log("Game Over");
        LoseSound.Play();
        if (score > PlayerPrefs.GetInt("BastScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        Time.timeScale = 0;
        LoseScreen.SetActive(true);
    }
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
}