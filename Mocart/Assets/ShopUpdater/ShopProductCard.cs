using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ShopProductCard : MonoBehaviour
{
    public TMP_InputField newName;
    public TMP_InputField newPrice;
    public TMP_InputField newDescription;

    [SerializeField] GameObject nameErrorIcon;
    [SerializeField] GameObject priceErrorIcon;
    [SerializeField] GameObject descriptionErrorIcon;
    public void SetCardData(ProductData data)
    {
        newName.text = data.name;
        newPrice.text = data.price.ToString();
        newDescription.text = data.description;
    }
    public bool VerifyName()
    {
        if(System.Text.RegularExpressions.Regex.IsMatch(newName.text, @"^[a-zA-Z0-9\s]*$") && newName.text.Length < 20 && newName.text.Length > 0) // name is 1-20 long, letters and numbers only
        {
            nameErrorIcon.SetActive(false);
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
        if(System.Text.RegularExpressions.Regex.IsMatch(newPrice.text, @"^\d+(\.\d+)?$") && newPrice.text.Length < 10 && newPrice.text.Length > 0) //price is 1-10 long, numbers only
        {
            priceErrorIcon.SetActive(false);
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
        if(System.Text.RegularExpressions.Regex.IsMatch(newDescription.text, @"^[a-zA-Z0-9\s]*$") && newDescription.text.Length < 60 && newDescription.text.Length > 0) //desc is 1-60 long, letters and numbers only
        {
            descriptionErrorIcon.SetActive(false);
            return true;
        }
        else
        {
            descriptionErrorIcon.SetActive(true);
            return false;
        }
    }
}
