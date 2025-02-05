using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopManagerUICoupler : MonoBehaviour
{
    [SerializeField] private UIScreensManager uiScreenManager;

    [SerializeField] private TagUpdater tagUpdater;

    [SerializeField] private Button startGameButton;

    [SerializeField] private Button restartGameButton;

    [SerializeField] private GameLoopManager gameLoopManager;

    private void Awake()
    {
        startGameButton.onClick.AddListener(gameLoopManager.ResetGame);

        restartGameButton.onClick.AddListener(gameLoopManager.ResetGame);

        gameLoopManager.OnCurrentPlayerChanged += tagUpdater.UpdateCurrentPlayerTag;

        gameLoopManager.OnGameOver += HandleGameOverEvent;
    }

    private void HandleGameOverEvent(GameOverEventData gameOverEventData)
    {
        tagUpdater.UpdateWinnerTag(gameOverEventData.winner);
        uiScreenManager.ToggleGameOverScreen(true);
    }
}
