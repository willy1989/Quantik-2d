using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreensManager : MonoBehaviour
{
    [SerializeField] private RectTransform startGameScreen;

    [SerializeField] private RectTransform gameOverScreen;

    [SerializeField] private Button startGameButton;

    [SerializeField] private Button restartGameButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(() => ToggleStartGameScreen(false));
        restartGameButton.onClick.AddListener(() => ToggleGameOverScreen(false));
    }

    private void ToggleStartGameScreen(bool onOff)
    {
        startGameScreen.gameObject.SetActive(onOff);
    }

    public void ToggleGameOverScreen(bool onOff)
    {
        gameOverScreen.gameObject.SetActive(onOff);
    }
}
