using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object _lock = new Object();
    private static T _instance;

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType(typeof(T)) as T;
                }
                return _instance;
            }
        }
    }
}