using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player")]
public class PlayerData : ScriptableObject
{
    public string currentCharacter;
    public float health;

    public float magnumSpeed, parvisSpeed;
    public float magnumJumpHeight, parvisJumpHeight;

    public float invicibilityFrames;

}
