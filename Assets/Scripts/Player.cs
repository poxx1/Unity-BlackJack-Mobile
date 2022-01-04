using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<GameObject> hand = new List<GameObject>();
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
        hand.Add(card);
    }
}
