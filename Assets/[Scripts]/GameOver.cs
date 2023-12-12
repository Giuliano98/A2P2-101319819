using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Threading.Tasks;

public class GameOver : MonoBehaviour
{
    public BackgroundMusic backgroundMusic;
    public AudioClip buttonSound;

    public float targetTimeInSeconds = 60f;
    float bonusMultiplier = 1.0f;

    int diamondMult = 100;
    int enemyMult = 50;

    int TimeScore;
    int DiamondScore;
    int EnemyScore;
    int TotalScore;

    public TextMeshProUGUI TimerTxt;
    public TextMeshProUGUI DiamondsTxt;
    public TextMeshProUGUI EnemiesTxt;
    public TextMeshProUGUI FinalScoreTxt;

    public GameplayManager gameplayManager;
    
    public TimeManager timeManager;

    private void Start()
    {
        //gameplayManager = FindObjectOfType<GameplayManager>();
        gameObject.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        gameObject.SetActive(true);
        timeManager.flag = true;
        backgroundMusic.PlayGameOverMusic();


        float timeDifference = timeManager.currentTime - targetTimeInSeconds;
        if (timeDifference <= -5)
            TimeScore = Mathf.RoundToInt(Mathf.Abs(timeDifference) * bonusMultiplier * 1.5f); 
        else if (timeDifference >= 5)
            TimeScore = Mathf.RoundToInt(Mathf.Abs(timeDifference) * bonusMultiplier * 0.8f);
        else
            TimeScore = Mathf.RoundToInt(Mathf.Abs(timeDifference) * bonusMultiplier);
        TimerTxt.text = string.Format("Total Time: {0} x Time Multiplier", timeManager.currentTime.ToString("0.0"));

        DiamondsTxt.text = string.Format("Total diamonds: {0} x 100", gameplayManager.FoundDiamonds);
        DiamondScore = gameplayManager.FoundDiamonds * diamondMult;

        EnemiesTxt.text = string.Format("Total enemies defeat: {0} x 50", gameplayManager.EnemiesDefeated);
        EnemyScore = gameplayManager.EnemiesDefeated * enemyMult;

        TotalScore = TimeScore + DiamondScore + EnemyScore;
        FinalScoreTxt.text = "Total Score: " + TotalScore;

    }


    public void ResetLevel()
    {
        AudioSource.PlayClipAtPoint(buttonSound, transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        AudioSource.PlayClipAtPoint(buttonSound, transform.position);
        SceneManager.LoadScene("MainMenu");
    }
}
