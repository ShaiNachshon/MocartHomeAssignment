using System.Collections.Generic;

[System.Serializable]
public class ProductData
{
    public ProductData(string _name, string _description, double _prioce) 
    {
        name = _name;
        description = _description;
        price= _prioce;
    }
    public string name;
    public string description;
    public double price;
}

[System.Serializable]
public class ProductList
{
    public List<ProductData> products;
}

