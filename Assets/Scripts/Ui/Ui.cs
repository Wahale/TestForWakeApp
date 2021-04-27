using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel,startPanel;
    [SerializeField] private Text scoreText, healtText,recordText;
    private static bool IsShowStartPanel = true;

    private void Update()
    {
        OpenDeathPanel();
        OutText();
        CheckStartPanel();
    }

    private void OpenDeathPanel()
    {
        if (Player.Health == 0)
            deathPanel.SetActive(true);
    }

    public void RestartLevel(int index)
    {
        SceneManager.LoadScene(index);
        Player.Health = 3;
        Player.Score = 0;
    }

    public void StartPlay()
    {
        startPanel.SetActive(false);
        IsShowStartPanel = false;
    }

    private void CheckStartPanel()
    {
        if (!IsShowStartPanel)
            startPanel.SetActive(false);
    }

    private void OutText()
    {
        healtText.text = "Health : " + Player.Health.ToString();
        scoreText.text = "Score : " + Player.Score.ToString();
        recordText.text = "Record : " + Player.SetRecord().ToString();
    }
}
