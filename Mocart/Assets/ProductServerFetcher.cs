using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ProductServerFetcher : MonoBehaviour
{
    [SerializeField] ProductInstantiater productInstantiater;

    private const string URL = "https://homework.mocart.io/api/products";

    public void GetProductsButon() //Button "GetProductsButton" in Hierarchy.
    {
        StartCoroutine(FetchProductData());
    }

    private IEnumerator FetchProductData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error fetching data: " + request.error);
            }
            else
            {
                string response = request.downloadHandler.text;
                Debug.Log("Response: " + response);

                ProductList productList = JsonUtility.FromJson<ProductList>(response);
                productInstantiater.NewShop(productList);
            }
        }
    }
}
