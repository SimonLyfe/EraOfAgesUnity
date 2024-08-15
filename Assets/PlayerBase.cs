using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerBase : Base
{
    void Start()
    {
        base.body = body;
        base.health = health;
    }

    void Update()
    {

    }
}
