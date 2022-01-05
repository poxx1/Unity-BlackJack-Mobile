using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Pepe : MonoBehaviour
{
    #region Sprites
    public List<Sprite> cardList;

    public Sprite Back;
    public Sprite As;
    public Sprite Jey;

    public GameObject card;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        int counter=0;

        foreach (var item in cardList)
        {
            var gameObj = Instantiate(card, this.transform);
            gameObj.GetComponent<SpriteRenderer>().sprite = item;
            gameObj.transform.position = new Vector3(transform.position.x+counter*0.5f, 0, -1*counter*0.1f);
            counter += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
