using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   //싱글톤
   static GameManager gameManager;
   public static GameManager Instance { get { return gameManager; } }

   //UI연결
   public Text scoreText;
   public Text livesText;
   public GameObject gameOverPanel;
   
   
   //게임상태 변수
   public int maxLives = 3; //생명최대갯수
   private int currentLives;// 현재생명변수
   private int currentScore = 0; //현재점수 :0점
   private bool isGameOver = false;
   
   
   private void Awake()
   {
      gameManager = this;
   }

   void Start()
   {
      currentLives = maxLives;
      Time.timeScale = 1; //게임 내에서 흘러가는 시간. 델타타임과 다름! 
      if (gameOverPanel != null) gameOverPanel.SetActive(false);
      UpdateUI();
   }

   void UpdateUI()
   {
      if(scoreText != null)scoreText.text = "점수"+currentScore;
      if(livesText !=null)livesText.text="생명"+currentLives;
   }

   public void AddScore(int score) //사과가 호출(점수+1)
   {
      if(isGameOver) return;
      currentScore += score;
      UpdateUI();
      Debug.Log("점수"+currentScore);
   }

   //똥이 호출
   public void DecreaseLife()
   {
      if(isGameOver) return;
      currentLives--;
      UpdateUI();

      if (currentLives <= 0)
      {
         GameOver();
      }
   }

   public void GameOver()
   {
      if(isGameOver) return;
      isGameOver = true;
      Time.timeScale = 0;
      
      if (gameOverPanel != null) gameOverPanel.SetActive(true);
      Debug.Log("GameOver");
   }

   public void RestartGame()
   {
      Time.timeScale = 1; //게임오버에서 0이 되었기 때문에 재도전은 타임이 1이어야 정상화됨
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

}
