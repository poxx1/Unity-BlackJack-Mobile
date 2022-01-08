using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> hand = new List<Card>();
    public string Name;
    //Tokens
    //Bet

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCard(Card card) //Adds a card to the player's hand
    {
        //var cardScript = card.GetComponent<Card>();
        //card.transform.parent = transform;
        // card.transform.localPosition = new Vector3(hand.Count*0.5f, 0, -1*hand.Count*0.01f);
        float newZ = -1f * hand.Count * 0.01f;
        card.MoveTo(transform.position + new Vector3(hand.Count*0.5f, 0, newZ));
        card.Flip();
        hand.Add(card);
    }

    public List<Card> GetCards()
    {
        return hand;
    }

    public void ClearHand()
    {
        hand.Clear();
    }
}
