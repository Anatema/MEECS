using ME.ECS;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GlobalEvent _gameStarted;
    [SerializeField]
    private GlobalEvent _gameEnded;

    [SerializeField]
    private List<Panel> _panels;
    // Start is called before the first frame update
    void Start()
    {
        _gameStarted.Subscribe(OpenGamePanel);
        _gameEnded.Subscribe(OpenEndGamePanel);
        OpenPanel(0);

    }
    private void OpenGamePanel(in Entity entity)
    {
        OpenPanel(1);
        _gameStarted.Unsubscribe(OpenGamePanel);
    }
    private void OpenEndGamePanel(in Entity entity)
    {
        OpenPanel(2);
        _gameEnded.Unsubscribe(OpenEndGamePanel);
    }
    public void OpenPanel(int index)
    {
        CloseAllPanels();
        if(_panels.Count > index && index >= 0)
        {
            _panels[index]?.OpenPanel();
        }
    }

    private void CloseAllPanels()
    {
        foreach (Panel panel in _panels)
        {
            panel?.ClosePanel();
        }
    }
   
}
