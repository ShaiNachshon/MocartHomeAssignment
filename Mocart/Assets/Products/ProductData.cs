using System.Collections.Generic;

[System.Serializable]
public class ProductData
{
    public string name;
    public string description;
    public float price;
}

[System.Serializable]
public class ProductList
{
    public List<ProductData> products;
}

