using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TagUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerTag;

    [SerializeField] private TextMeshProUGUI currentPlayerTag;

    public void UpdateWinnerTag(Player player)
    {
        if (player == null)
            return;

        if (player.ElementColor == GridElement.GridElementColor.White)
            winnerTag.text = "White player won!";
        else if (player.ElementColor == GridElement.GridElementColor.Black)
            winnerTag.text = "Black player won!";
    }

    public void UpdateCurrentPlayerTag(Player player)
    {
        if (player == null)
            return;

        if (player.ElementColor == GridElement.GridElementColor.White)
            currentPlayerTag.text = "White player";
        else if (player.ElementColor == GridElement.GridElementColor.Black)
            currentPlayerTag.text = "Black player";
    }
}
