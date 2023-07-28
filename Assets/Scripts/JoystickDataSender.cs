using ME.ECS;
using Project.Markers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDataSender : MonoBehaviour
{
    [SerializeField]
    private Joystick _joyStick;
    private void Awake()
    {
        _joyStick = GetComponent<Joystick>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Worlds.currentWorld.AddMarker(new HorizontalMovementMarker() { Input = _joyStick.Direction.x });

    }
}
