using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShopUIUpdater : MonoBehaviour
{
    [SerializeField] ProductInstantiater productInstantiater;
    [SerializeField] Transform cardsParent;
    [SerializeField] ShopProductCard productCardPrefab;

    [SerializeField] GameObject postSaveChangesPanel;
    [SerializeField] TextMeshProUGUI postSaveChangesText;

    List<ShopProductCard> productCards = new List<ShopProductCard>();

    public void InstantiateNewCards() //"UpdateShopButton" button in Hierarchy
    {
        List<ProductDisplay> products = productInstantiater.GetListOfProducts();
        foreach (ProductDisplay product in products)
        {
            ShopProductCard newProductCard = Instantiate(productCardPrefab, cardsParent);
            newProductCard.SetCardData(product.myData);
            productCards.Add(newProductCard);
        }
    }
    public void BackButton() //"Back" button in Hierarchy
    {
        DestroyOldCards();
    }
    void DestroyOldCards()
    {
        foreach (var item in productCards)
        {
            Destroy(item.gameObject);
        }
        productCards.Clear();
    }
    public void AcceptChangesButton() //"SaveChanges" button in Hierarchy
    {
        bool foundErrors = VerifyFieldInputs();
        if (!foundErrors)
        {
            ReadCardValues(out List<ProductData> newProductValues);
            productInstantiater.UpdateProducts(newProductValues);
        }
        EnableConfirmationPanel(foundErrors);
    }
    bool VerifyFieldInputs()
    {
        bool foundErrors = false;
        foreach (var card in productCards)
        {
            if (card.VerifyDescription() & card.VerifyName() & card.VerifyPrice() && !foundErrors) //using & instead of && for the method side effects to go through
                continue;

            foundErrors = true;
        }
        return foundErrors;
    }
    void EnableConfirmationPanel(bool foundErrors)
    {
        if (foundErrors)
        {
            postSaveChangesText.text = "Errors Found!\nHover over the exclamation marks to view them.";
            postSaveChangesText.color = Color.red;
        }
        else
        {
            postSaveChangesText.text = "Changes Saved Succesfuly!";
            postSaveChangesText.color = Color.green;
        }

        postSaveChangesPanel.SetActive(true);
    }
    void ReadCardValues(out List<ProductData> newProductValues)
    {
        newProductValues = new List<ProductData>();
        foreach (var card in productCards)
        {
            double.TryParse(card.newPrice.text, out double result);
            ProductData newData = new ProductData(card.newName.text, card.newDescription.text, result);
            newProductValues.Add(newData);
        }
    }
}
