using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUIUpdater : MonoBehaviour
{
    [SerializeField] ProductInstantiater productInstantiater;
    [SerializeField] Transform cardsParent;
    [SerializeField] ShopProductCard productCardPrefab;

    [SerializeField] GameObject postSaveChangesPanel;
    [SerializeField] TextMeshProUGUI postSaveChangesText;

    List<ShopProductCard> productCards = new List<ShopProductCard>();

    private void OnEnable()
    {
        InstantiateNewCards();
    }

    void InstantiateNewCards()
    {
        List<ProductDisplay> products = productInstantiater.GetListOfProducts();
        foreach (ProductDisplay product in products)
        {
            ShopProductCard newProductCard = Instantiate(productCardPrefab, cardsParent);
            newProductCard.SetCardData(product.myData);
            productCards.Add(newProductCard);
        }
    }

    void DestroyOldCards()
    {
        foreach (var item in productCards)
        {
            Destroy(item.gameObject);
        }
        productCards.Clear();
    }
    public void AcceptChangesButton() //"Update" button in Hierarchy
    {
        bool foundErrors = false;
        foreach (var card in productCards)
        {
            if ( !(card.VerifyDescription() & card.VerifyName() & card.VerifyPrice()) ) //using & instead of && for the method side effects to go through
                foundErrors = true;
        }

        if (foundErrors)
        {
            postSaveChangesText.text = "Errors Found! Hover over the exclamation marks to view them.";
            postSaveChangesText.color = Color.red;
        }
        else
        {
            postSaveChangesText.text = "Changes Saved Succesfuly!";
            postSaveChangesText.color = Color.green;

            //TODO: update the products.
        }

        postSaveChangesPanel.SetActive(true);
    }
    public void BackButton() //"Back" button in Hierarchy
    {
        DestroyOldCards();
    }
}
