using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Card : MonoBehaviour
{
    #region Variables
    public int number; 
    public int symbol;
    public Sprite spriteCard;
    public Sprite spriteCardBack;
    #endregion
    
    #region Methods

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteCard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        return $"Num: {number} - Sym: {symbol}";
    }
}