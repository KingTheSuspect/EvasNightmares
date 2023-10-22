using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private static DontDestroyMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
