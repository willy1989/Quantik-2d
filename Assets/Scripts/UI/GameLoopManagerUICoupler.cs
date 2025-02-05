using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopManagerUICoupler : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    [SerializeField] private TextMeshProUGUI currentPlayerTag;

    [SerializeField] private GameLoopManager gameLoopManager;

    private void Awake()
    {
        startGameButton.onClick.AddListener(gameLoopManager.ResetGame);

        gameLoopManager.OnCurrentPlayerChanged += UpdateCurrentPlayerTag;

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
}
