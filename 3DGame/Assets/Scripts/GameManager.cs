using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _startText;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] GameObject _showFinishWindow;
    [SerializeField] CoinManager _coinManager;

    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }
    public void Play()
    {
        _startText.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();
    }
    public void ShowFinishWindow()
    {
        _showFinishWindow.SetActive(true);
    }
    public void NextLevel()
    {
       
        var next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveToProgress();
            SceneManager.LoadScene(next);
        }
    }
}
