using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Deck : MonoBehaviour
{
    #region Variables
    public int deckQuantity = 6; //Mostly used 6 to 8.

    [SerializeField]
    public List<CardData> listOfCards = new List<CardData>();
    private System.Random rn1 = new System.Random();

    public GameObject cardPrefab;
    public List<Sprite> cardSprites;
    private int counter = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < deckQuantity; i++)
        {
            CreateDeck();
            Shuffle();
        }
    }

    #region Methods
    private void CreateDeck()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                listOfCards.Add(new CardData() { Number = j, Symbol = i });
            }
        }
    }
    public void Shuffle()
    {
        CardData tempCd;
        for (int i = 0; i < 200; i++)
        {
            var index1 = rn1.Next(0, listOfCards.Count()-1);
            var index2 = rn1.Next(0, listOfCards.Count()-1);

            tempCd = listOfCards[index1];
            listOfCards[index1] = listOfCards[index2];
            listOfCards[index2] = tempCd;
        }
    }

    private CardData PickCard()
    {
        var card = listOfCards.First();
        listOfCards.Remove(card);
        Debug.Log(card.ToString());
        return card;
    }

    public GameObject PickCardAsGameObject()
    {
        var card = PickCard();
        var obj = Instantiate(cardPrefab);

        int imageIndex = card.Number + card.Symbol*13;
        var imageSprite = cardSprites[imageIndex];

        // obj.GetComponent<SpriteRenderer>().sprite = imageSprite;

        var cardScript = obj.GetComponent<Card>();
        cardScript.SpriteCard = imageSprite;
        cardScript.Number = card.Number;
        cardScript.Symbol = card.Symbol;

        obj.transform.position = transform.position;

        counter++;
        //Debug.Log(card.ToString());

        return obj;
    }

    #endregion
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            PickCardAsGameObject();
    }

    [Serializable]
    public class CardData 
    {
        [SerializeField]
        public int Number { get; set; }

        [SerializeField]
        public int Symbol { get; set; }

        public override string ToString()
        {
            return "N: " + Number + " S: " + Symbol;
        }
    }
}