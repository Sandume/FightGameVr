using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int currentWave = 0;
    [SerializeField] private int maxWave = 5;

    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject swordMan;

    //Dont initialize wave 0, the game while start at the wave 1;
    [SerializeField] private int[] nbArcherPerWaveSpawn1;
    [SerializeField] private int[] nbSwordManPerWaveSpawn1;
    [SerializeField] private Vector3[] spawn1Position;

    [SerializeField] private int[] nbArcherPerWaveSpawn2;
    [SerializeField] private int[] nbSwordManPerWaveSpawn2;
    [SerializeField] private Vector3[] spawn2Position;

    [SerializeField] private int[] nbArcherPerWaveSpawn3;
    [SerializeField] private int[] nbSwordManPerWaveSpawn3;
    [SerializeField] private Vector3[] spawn3Position;

    [SerializeField] private int[] nbArcherPerWaveSpawn4;
    [SerializeField] private int[] nbSwordManPerWaveSpawn4;
    [SerializeField] private Vector3[] spawn4Position;

    static private WaveManager instance;

    public int nbEnnemiAlive = 0;
    static public WaveManager Instance
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

    // Update is called once per frame
    void Update()
    {
        if (nbEnnemiAlive <= 0)
        {
            currentWave++;
            if (currentWave <= maxWave)
            {

                for (int i = 0; i < nbArcherPerWaveSpawn1[currentWave]; i++)
                {
                    Instantiate(archer, spawn1Position[i], Quaternion.identity);
                    nbEnnemiAlive++;
                }
                for (int i = 0; i < nbSwordManPerWaveSpawn1[currentWave]; i++)
                {
                    Instantiate(swordMan, spawn1Position[i + nbArcherPerWaveSpawn1[currentWave]], Quaternion.identity);
                    nbEnnemiAlive++;
                }     
                for (int i = 0; i < nbArcherPerWaveSpawn2[currentWave]; i++)
                {
                    Instantiate(archer, spawn2Position[i], Quaternion.identity);
                    nbEnnemiAlive++;
                }
                for (int i = 0; i < nbSwordManPerWaveSpawn2[currentWave]; i++)
                {
                    Instantiate(swordMan, spawn2Position[i + nbArcherPerWaveSpawn2[currentWave]], Quaternion.identity);
                    nbEnnemiAlive++;
                }    
                
                for (int i = 0; i < nbArcherPerWaveSpawn3[currentWave]; i++)
                {
                    Instantiate(archer, spawn3Position[i], Quaternion.identity);
                    nbEnnemiAlive++;
                }
                for (int i = 0; i < nbSwordManPerWaveSpawn3[currentWave]; i++)
                {
                    Instantiate(swordMan, spawn3Position[i + nbArcherPerWaveSpawn3[currentWave]], Quaternion.identity);
                    nbEnnemiAlive++;
                }               
                for (int i = 0; i < nbArcherPerWaveSpawn4[currentWave]; i++)
                {
                    Instantiate(archer, spawn4Position[i], Quaternion.identity);
                    nbEnnemiAlive++;
                }
                for (int i = 0; i < nbSwordManPerWaveSpawn4[currentWave]; i++)
                {
                    Instantiate(swordMan, spawn4Position[i + nbArcherPerWaveSpawn4[currentWave]], Quaternion.identity);
                    nbEnnemiAlive++;
                }
            }
            else
            {
                //Implement Win
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
