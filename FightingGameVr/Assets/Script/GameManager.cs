using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    static private GameManager instance;

    public List<Vector3> coverPoint = new List<Vector3>();
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject(nameof(GameManager));
                obj.AddComponent<GameManager>();
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(instance);
            return;
        }
    }
}
