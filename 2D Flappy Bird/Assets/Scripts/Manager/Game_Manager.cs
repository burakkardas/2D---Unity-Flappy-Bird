using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Bird_Controller bird;

    [Header("Gameobjects")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _medal;

    [Header("Medals")]
    [SerializeField] private Sprite[] _medalsImg;

    [Header("Texts")]
    [SerializeField] private TMP_Text[] _scoreTexts;
    [SerializeField] private TMP_Text _bestScoreText;

    [Header("Gameplay")]
    public int _score;
    public bool _isStart = false;
    public bool _isDead = false;
    void Start()
    {
        StartCoroutine(StartBird());
        Time.timeScale = 1;
    }

    void Update()
    {
        for(int i = 0; i < 2; i++) {
            _scoreTexts[i].text = _score.ToString();
        }

        _bestScoreText.text = PlayerPrefs.GetInt("_bestScore").ToString();

        if(_score > PlayerPrefs.GetInt("_bestScore")) {
            PlayerPrefs.SetInt("_bestScore", _score);
        }

        CheckMedal();
    }

    IEnumerator StartBird() {
        yield return new WaitForSeconds(1f);
        bird.GetComponent<Rigidbody2D>().gravityScale = 3;
        _isStart = true;
    }

    public void GameOver() {
        _gameOverPanel.SetActive(true);
        _isDead = true;
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    private void CheckMedal() {
        if(_score >= 10  && _score <= 20) {
            _medal.GetComponent<Image>().sprite = _medalsImg[0];
        }
        else if(_score >= 21  && _score <= 40) {
            _medal.GetComponent<Image>().sprite = _medalsImg[1];
        }
        else if(_score >= 41  && _score <= 60) {
            _medal.GetComponent<Image>().sprite = _medalsImg[2];
        }
        else if(_score >= 61  && _score <= 80) {
            _medal.GetComponent<Image>().sprite = _medalsImg[3];
        }
        else {
            _medal.GetComponent<Image>().enabled = false;
        }
    }
}
