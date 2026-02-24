using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    // Awake lu dès le début
    void Awake()
    {
        foreach(var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }


}
