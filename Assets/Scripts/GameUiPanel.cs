using Project.Features;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUiPanel : Panel
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    public void Start()
    {
        DuckFeature.ScoreChangedEvent.AddListener(ScoreChanged);
    }
    private void ScoreChanged(int i)
    {
        _scoreText.text = $"Score: {i}";
    }
    public void OnDestroy()
    {
        DuckFeature.ScoreChangedEvent.RemoveListener(ScoreChanged);
    }

}
