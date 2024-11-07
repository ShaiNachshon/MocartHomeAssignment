using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopProductCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] TextMeshProUGUI description;

    [SerializeField] TextMeshProUGUI newName;
    [SerializeField] TextMeshProUGUI newPrice;
    [SerializeField] TextMeshProUGUI newDescription;

    [SerializeField] GameObject nameErrorIcon;
    [SerializeField] GameObject priceErrorIcon;
    [SerializeField] GameObject descriptionErrorIcon;
    public void SetCardData(ProductData data)
    {
        name.text = data.name;
        price.text = data.price.ToString();
        description.text = data.description;
    }
    public bool VerifyName()
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(newName.text, @"^[a-zA-Z0-9\s]*$"))
        {
            return true;
        }
        else
        {
            nameErrorIcon.SetActive(true);
            return false;
        }
    }
    public bool VerifyPrice()
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(newPrice.text, @"^\d+$"))
        {
            return true;
        }
        else
        {
            priceErrorIcon.SetActive(true);
            return false;
        }
    }
    public bool VerifyDescription() 
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(newDescription.text, @"^[a-zA-Z0-9\s]*$"))
        {
            return true;
        }
        else
        {
            descriptionErrorIcon.SetActive(true);
            return false;
        }
    }
}
