using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour
{
    public GameObject game_manager;
    
    public Text scoreText;
    public Text bestScoreText;
    public Text lastScoreText;
    public Image musicBtn;

    public Sprite musicOn, musicOff;
    public GameObject menuPanel;

    public AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip menuSound;
    public AudioClip gameoverSound;
    

    [HideInInspector]
    public int score;

    private void Start()
    {
        
        bestScoreText.text = "Best : " + PlayerPrefs.GetInt("best_score", 00);
        lastScoreText.text = "Last : " + PlayerPrefs.GetInt("last_score" ,00);
        if (PlayerPrefs.GetInt("canPlayMusic", 1) < 1)
        {
            audioSource.enabled = false;
            musicBtn.sprite = musicOff;
        }
        
        audioSource.clip = menuSound;
        
    }

    public void TapToStart()
    {
        game_manager.SetActive(true);
        scoreText.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        audioSource.volume = 0.2f;

    }
    public void Increase_Score()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void Set_BestandLastScore()
    {
        if (score > PlayerPrefs.GetInt("best_score", 0))
        {
            PlayerPrefs.SetInt("best_score", score);
        }
        PlayerPrefs.SetInt("last_score", score);
        //Ads-----------------------------------------------------------
        if (PlayerPrefs.GetInt("ad_time", 0) == 7)
        {
            
            AdController.instance.showVideoAd();
            
            PlayerPrefs.SetInt("ad_time", 0);
        }
       
        PlayerPrefs.SetInt("ad_time", PlayerPrefs.GetInt("ad_time", 0) + 1);
        SceneManager.LoadScene("GameScene");
    }
    public void Music()
    {
        if (PlayerPrefs.GetInt("canPlayMusic", 1) == 1)
        {
            audioSource.enabled = false;
            musicBtn.sprite = musicOff;
            PlayerPrefs.SetInt("canPlayMusic", 0);
        }
        else
        {
            PlayerPrefs.SetInt("canPlayMusic", 1);
            audioSource.enabled = true;
            musicBtn.sprite = musicOn;
        }
    }
}
