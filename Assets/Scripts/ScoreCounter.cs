using Project.Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        DuckFeature.ScoreChangedEvent.AddListener(ScoreChanged);
    }
    private void ScoreChanged(int i)
    {
        currentScore = i;
    }
    private void OnDestroy()
    {
        DuckFeature.ScoreChangedEvent.RemoveListener(ScoreChanged);
    }
}
