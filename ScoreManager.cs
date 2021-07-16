using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
   
    public TextMeshProUGUI text;
    [SerializeField] GameObject winMenu;
    int score = 0;
  


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 4100)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        winMenu.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void Menu()
    {
        winMenu.SetActive(false);
        SceneManager.LoadScene("Play");
        Time.timeScale = 1;
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();

    }
}
