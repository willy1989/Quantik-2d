using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreensManager : MonoBehaviour
{
    [SerializeField] private RectTransform startGameScreen;

    [SerializeField] private Button startGameButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(() => ToggleStartGameScreen(false));
    }

    private void ToggleStartGameScreen(bool onOff)
    {
        startGameScreen.gameObject.SetActive(onOff);
    }
}
