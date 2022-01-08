using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public Player player;
    public Deck deck;
    public Player dealer;

    public Text dealerCounter;
    public Text playerCounter;

    public UiController UiController;

    private readonly List<Player> _players = new List<Player>();

    private int _currentTurn;

    // Start is called before the first frame update
    void Start()
    {
        dealerCounter.text = 0.ToString();
        playerCounter.text = 0.ToString();
        
        AddPlayer(player);
        
        UiController.buttonDeal.interactable = true;
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }
    
    public void StartRound()
    {
        Reset();
        Debug.Log("Start Round!");

        _currentTurn = 0;
        UiController.buttonDeal.interactable = false;
        StartCoroutine(DealStartCards());
    }

    public void RoundEnded()
    {
        UiController.DisableAll();
        UiController.buttonDeal.interactable = true;
    }

    public void OnButtonStandClicked()
    {
        if (GetCurrentPlayer() == player) Stand(player);
    }

    public void OnButtonHitClicked()
    {
        if (GetCurrentPlayer() == player) Hit(player);
    }

    public Player GetCurrentPlayer()
    {
        if (_currentTurn >= _players.Count)
        {
            return dealer;
        }
        else
        {
            return _players[_currentTurn];
        }
    }

    public void UpdateScoreText(Player player)
    {
        if (this.player == player)
        {
            playerCounter.text = player.CurrentScore.ToString();
        }
        else
        {
            dealerCounter.text = player.CurrentScore.ToString();
        }
    }

    public void Stand(Player player)
    {
        NextTurn();
    }

    public void Hit(Player player)
    {
        DealCard(player, player == this.player ? playerCounter : dealerCounter);
    }
    
    public void Bust(Player player)
    {
        NextTurn();
    }

    public void Blackjack(Player player)
    {
        NextTurn();
    }

    public void TwentyOne(Player player)
    {
        NextTurn();
    }

    public IEnumerator DealStartCards()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (var player in _players)
            {
                DealCard(player, playerCounter, false);
                yield return new WaitForSeconds(0.2f);
            }
            DealCard(dealer, dealerCounter, false);
            yield return new WaitForSeconds(0.2f);
        }
        
        UiController.buttonHit.interactable = true;
        UiController.buttonStand.interactable = true;
        
        NotifyTurn(_players[_currentTurn]);
    }

    private void NotifyTurn(Player player)
    {
        if (player != this.player)
        {
            UiController.DisableAll();
        }
        
        if (player.CurrentScore == 21)
        {
            if (player.GetCards().Count == 2)
            {
                Blackjack(player);
            }
            else
            {
                TwentyOne(player);
            }
        }
        else if (player.CurrentScore > 21)
        {
            Bust(player);
        } 
        else
        {
            Debug.Log("Turn of: " + player.Name);
            player.NotifyTurn(this);
        }
    }

    private void NextTurn()
    {
        _currentTurn++;
        if (_currentTurn < _players.Count)
        {
            NotifyTurn(_players[_currentTurn]);
        }
        else if (_currentTurn - _players.Count == 0)
        {
            NotifyTurn(dealer);
        }
        else
        {
            RoundEnded();
        }
    }
    
    public void DealCard(Player player, Text count, bool notify = true)
    {
        // Deal card to player
        var card = deck.PickCardAsGameObject().GetComponent<Card>();
        player.AddCard(card);
        
        // Update hand's score
        var score = player.CurrentScore;
        count.text = score.ToString();
        
        if (notify) NotifyTurn(player);
    }

    public void Reset()
    {
        var pepito = player.GetComponent<Player>();
        var robertito = dealer.GetComponent<Player>();

        foreach (var card in pepito.GetCards())
        {
            Destroy(card.gameObject);
        }
        foreach (var card in robertito.GetCards())
        {
            Destroy(card.gameObject);
        }

        dealerCounter.text = 0.ToString();
        playerCounter.text = 0.ToString();

        pepito.ClearHand();
        robertito.ClearHand();
    }
}