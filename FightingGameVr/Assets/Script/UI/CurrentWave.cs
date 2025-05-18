using TMPro;
using UnityEngine;

public class CurrentWave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Current Wave : " + WaveManager.Instance.CurrentWave;
    }
}
