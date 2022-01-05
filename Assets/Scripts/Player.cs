using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>();
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

    public void AddCard(GameObject card) //Adds a card to the player's hand
    {
        card.transform.parent = transform;
        card.transform.localPosition = new Vector3(hand.Count*0.5f, 0, -1*hand.Count*0.01f);
        hand.Add(card);
    }

    public List<GameObject> GetCards()
    {
        return hand;
    }

    public void ClearHand()
    {
        hand.Clear();
    }
}
