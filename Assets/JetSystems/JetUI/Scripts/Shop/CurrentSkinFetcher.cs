using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JetSystems;

public class CurrentSkinFetcher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopManager;
    void Awake()
    {
        var shop = shopManager.GetComponent<ShopManager>();
        shop.LoadSavedData();
    
        transform.GetComponent<Image>().sprite = shop.itemsSprites[shop.CurrSpriteIndex()];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
