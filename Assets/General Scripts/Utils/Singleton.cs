using UnityEngine;

//Singletons will stay alive/synced throughout scenes
//Credit to danqzq <3

//Example of how to use: public class className : Singleton<className>
//and to call it, use className.Instance :)
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance) return instance;

            instance = FindObjectOfType<T>();

            if (!instance) instance = new GameObject(typeof(T).ToString()).AddComponent<T>();

            return instance;
        }
    }

    public static bool HasInstance => instance != null;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
