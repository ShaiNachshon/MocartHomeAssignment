using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProductDisplay : MonoBehaviour
{
    public ProductData myData;
    [SerializeField] TextMeshPro nameText;
    [SerializeField] TextMeshPro priceText;
    [SerializeField] TextMeshPro descText;

    public void SetProduct(ProductData product)
    {
        myData = product;
        nameText.text = product.name;
        priceText.text = '$' + product.price.ToString();
        descText.text = product.description;
    }
}
