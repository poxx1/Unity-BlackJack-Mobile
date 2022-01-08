using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected List<Card> _hand = new List<Card>();
    public string Name;
    public int CurrentScore { get; set; }

    public float spaceBetweenCards = 0.7f;
    //Tokens
    //Bet

    public virtual void AddCard(Card card, bool flip = true)
    {
        _hand.Add(card);
        if (flip)
        {
            card.Flip();
            CurrentScore = CalculateScore(_hand);
        }
        ReorderCards();
    }

    private void ReorderCards()
    {
        if (_hand.Count > 0)
        {
            // float cardWidth = _hand[0].GetComponent<SpriteRenderer>().bounds.size.x;
            float widthPerCard = spaceBetweenCards;
            float totalWidth = (widthPerCard * (_hand.Count - 1));

            float startX = -(totalWidth / 2f);
            for (int i = 0; i < _hand.Count; i++)
            {
                float z = -1f * i * 0.01f;
                _hand[i].MoveTo(transform.position + new Vector3(startX + i * widthPerCard, 0, z));
            }
        }
    }

    public List<Card> GetCards()
    {
        return _hand;
    }

    public void ClearHand()
    {
        _hand.Clear();
    }

    protected int CalculateScore(List<Card> listCards)
    {
        var total = listCards.Aggregate(0, (acc, card) => {
            var value = Math.Min(card.Number + 1, 10);
            return acc+ value + (value==1 ? 10:0);
        });

        var acesQuantity = listCards.Count(x => x.Number == 0);

        while(total > 21 && acesQuantity>0)
        {
            acesQuantity--;
            total -= 10;
        }

        return total;
    }

    public virtual void NotifyTurn(GameController gameController)
    {
    }
}
