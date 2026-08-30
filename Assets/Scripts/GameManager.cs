using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject canvas;

    private void Awake()
    {
        instance = this;
    }
}
