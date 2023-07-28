using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandomizaer : MonoBehaviour
{
    private Animation _animation;
    // Start is called before the first frame update
    void Awake()
    {
        _animation = GetComponent<Animation>();
    }
    private void Start()
    {
        float lengh = _animation.clip.length;
        float randomTime = Random.Range(0, lengh);
        _animation[_animation.clip.name].time = randomTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
