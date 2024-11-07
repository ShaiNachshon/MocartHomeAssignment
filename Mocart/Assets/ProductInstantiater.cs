using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInstantiater : MonoBehaviour
{
    [SerializeField] ProductDisplay productPrefab;
    [SerializeField] Transform productsParent;

    List<ProductDisplay> instantiatedProducts = new List<ProductDisplay>();
    public void NewShop(ProductList productList)
    {
        DestroyProducts();

        Vector3 startPos = new Vector3(-3.5f, 2, 0.65f);
        Vector3 offSet = new Vector3(3.5f, 0, 0);
        InstantiateProducts(startPos, offSet, productList.products);
    }
    void DestroyProducts()
    {
        foreach (ProductDisplay product in instantiatedProducts)
        {
            Destroy(product.gameObject);
        }
        instantiatedProducts.Clear();
    }
    void InstantiateProducts(Vector3 startPos, Vector3 offSet, List<ProductData> productsToInstantiate)
    {
        int i = 0;
        foreach (var productData in productsToInstantiate)
        {
            ProductDisplay newProduct = Instantiate(productPrefab, productsParent);
            newProduct.transform.localPosition = startPos + offSet * i;
            newProduct.SetProduct(productData);
            instantiatedProducts.Add(newProduct);
            i++;
        }
    }
    public List<ProductDisplay> GetListOfProducts()
    {
        return instantiatedProducts;
    }
}
