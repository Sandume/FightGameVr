using TMPro;
using UnityEngine;

public class RemainsEnemy : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Remains Enemy " + WaveManager.Instance.nbEnnemiAlive;
    }
}
