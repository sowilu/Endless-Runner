using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int points = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        points = Mathf.FloorToInt(timer);
        scoreText.text = points.ToString("D5");
    }
}
