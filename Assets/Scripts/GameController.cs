using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject deck;
    public GameObject dealer;

    public Text dealerCounter;
    public Text playerCounter;

    // Start is called before the first frame update
    void Start()
    {
        dealerCounter.text = 0.ToString();
        playerCounter.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
            Restc(player,playerCounter);
        if (Input.GetKeyDown(KeyCode.F3))
            Restc(dealer,dealerCounter);
        if (Input.GetKeyDown(KeyCode.F4))
            Reset();
    }

    public void Restc(GameObject pj, Text count)
    {
        var pjComponent = pj.GetComponent<Player>();
        var card = deck.GetComponent<Deck>().PickCardAsGameObject();
        pjComponent.AddCard(card);
        var score = CalculateScore(pjComponent.GetCards().Select(x=>x.GetComponent<Card>()).ToList());
        count.text = score.ToString();
    }

    public void Reset()
    {
        var pepito = player.GetComponent<Player>();
        var robertito = dealer.GetComponent<Player>();

        foreach (var card in pepito.GetCards())
        {
            Destroy(card);
        }
        foreach (var card in robertito.GetCards())
        {
            Destroy(card);
        }

        dealerCounter.text = 0.ToString();
        playerCounter.text = 0.ToString();

        pepito.ClearHand();
        robertito.ClearHand();
    }

    public int CalculateScore(List<Card> listCards)
    {
        var total = listCards.Aggregate(0, (acc, card) => {
            var value = Math.Min(card.number + 1, 10);
            return acc+ value + (value==1 ? 10:0);
        });

        var acesQuantity = listCards.Count(x => x.number == 0);

        while(total > 21 && acesQuantity>0)
        {
            acesQuantity--;
            total -= 10;
        }

        return total;
    }
}