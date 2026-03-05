using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plusieurs instance de GameOverManager");
            return;
        }
        instance = this; 
    }

    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        //Reset nb coins
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        //Recharger la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Replacer player au spawn et réactiver les mouvements + vie au max
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
        
    }

    public void MainMenuButton()
    {
        
    }

    public void QuitButtton()
    {
        Application.Quit(); //Fermer le jeu
    }
}
