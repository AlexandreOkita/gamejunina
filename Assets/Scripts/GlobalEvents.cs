using UnityEngine;
using System;

public class GlobalEvents : MonoBehaviour
{
    public Action OnDestroyProjectiles;

    static GlobalEvents _instance;
    public static GlobalEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GlobalEvents>();
            }

            return _instance;
        }

        private set
        {
            _instance = value;
        }
    }
}
