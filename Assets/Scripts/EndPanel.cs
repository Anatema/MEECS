using Project.Features;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndPanel : Panel
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _duckSize;
    private void Start()
    {
        _restartButton.onClick.AddListener(() => { UnityEngine.SceneManagement.SceneManager.LoadScene(0); });
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        ScoreChanged(ScoreCounter.currentScore);
    }
    private void ScoreChanged(int i)
    {
        _scoreText.text = $"Final score: {i}";
        _duckSize.text = $"Duck lengh: {i + 2}";
    }
    private void OnDestroy()
    {
        _restartButton.onClick.RemoveAllListeners();
        
    }
}
