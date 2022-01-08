using System.Collections;
using UnityEngine;

public class PlayerDealer : Player
{
    public override void AddCard(Card card, bool flip = true)
    {
        base.AddCard(card, GetCards().Count != 1);
    }

    private IEnumerator Play(GameController gameController)
    {
        yield return new WaitForSeconds(0.75f);
        
        if (!GetCards()[1].IsVisible)
        {
            GetCards()[1].Flip();
            CurrentScore = CalculateScore(_hand);
            gameController.UpdateScoreText(this);
            yield return new WaitForSeconds(1f);
        }
        
        if (CurrentScore < 17)
        {
            gameController.Hit(this);
        }
        else
        {
            gameController.Stand(this);
        }
    }

    public override void NotifyTurn(GameController gameController)
    {
        StartCoroutine(Play(gameController));
    }
}