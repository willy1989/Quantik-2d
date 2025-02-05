using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopManagerUICoupler : MonoBehaviour
{
    [SerializeField] private UIScreensManager uiScreenManager;

    [SerializeField] private Button startGameButton;

    [SerializeField] private Button restartGameButton;

    [SerializeField] private TextMeshProUGUI currentPlayerTag;
    [SerializeField] private TextMeshProUGUI winnerTag;

    [SerializeField] private GameLoopManager gameLoopManager;

    private void Awake()
    {
        startGameButton.onClick.AddListener(gameLoopManager.ResetGame);

        restartGameButton.onClick.AddListener(gameLoopManager.ResetGame);

        gameLoopManager.OnCurrentPlayerChanged += UpdateCurrentPlayerTag;

        gameLoopManager.OnGameOver += () => uiScreenManager.ToggleGameOverScreen(true);
        gameLoopManager.OnGameOverWiner += UpdateWinnerTag;
    }

    private void UpdateCurrentPlayerTag(Player player)
    {
        if (player == null)
            return;

        if (player.ElementColor == GridElement.GridElementColor.White)
            currentPlayerTag.text = "White player";
        else if (player.ElementColor == GridElement.GridElementColor.Black)
            currentPlayerTag.text = "Black player";
    }

    private void UpdateWinnerTag(Player player)
    {
        if (player == null)
            return;

        if (player.ElementColor == GridElement.GridElementColor.White)
            winnerTag.text = "White player won!";
        else if (player.ElementColor == GridElement.GridElementColor.Black)
            winnerTag.text = "Black player won!";
    }
}
