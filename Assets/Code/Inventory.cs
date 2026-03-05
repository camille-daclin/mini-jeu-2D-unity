using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int nbCoins;
    public Text nbCoinsText;
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plusieurs inventaire");
        }
        instance = this; //Accedez à l'inventaire de n'importe où
    }

    public void AddCoins(int count)
    {
        nbCoins += count;
        nbCoinsText.text = nbCoins.ToString(); 
    }

    public void RemoveCoins(int count)
    {
        nbCoins -= count;
        nbCoinsText.text = nbCoins.ToString();
    }
}
