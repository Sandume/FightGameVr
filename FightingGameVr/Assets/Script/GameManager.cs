using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public class CoverPoint
    {
        public Vector3 position;
        public bool isOccupied;
    }

    static private GameManager instance;
    public int score = 0; 

    public List<CoverPoint> coverPoint = new List<CoverPoint>();
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
