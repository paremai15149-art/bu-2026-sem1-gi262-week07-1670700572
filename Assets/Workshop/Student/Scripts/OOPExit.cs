using Searching;
using UnityEngine;

namespace Solution
{
    public class OOPExit : Identity
    {
        public Leaderboard leaderboard;
        public string ItemToOpen = "Key";
        public int ItemAmountToOpen = 2;

        private int CalculateScore()
        {
            return 0;
        }

        public override bool Hit()
        {
            bool IsHasItemAmount = mapGenerator.player.inventory.HasItem(ItemToOpen, ItemAmountToOpen);

            if (IsHasItemAmount)
            {
                mapGenerator.player.inventory.UseItem(ItemToOpen, ItemAmountToOpen);
                leaderboard.gameObject.SetActive(true);

                Debug.Log("You win");

                int score = CalculateScore();
                string playerName = mapGenerator.player.Name;

                leaderboard.RecordScore(
                    new PlayerScore(playerName, score)
                );

                leaderboard.ShowleaderBoard();

                return true;
            }
            else
            {
                Debug.Log("Need Item " + ItemToOpen + " to Open");
                return false;
            }
        }
    }
}