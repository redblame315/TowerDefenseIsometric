using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flexible UI Data")]
public class FlexibleUIData : ScriptableObject
{
    public Sprite buttonSprite;
    public SpriteState spriteState;

    [Header("Default Button Settings")]
    public Color defaultColor;
    public Sprite defaultIcon;

    [Header("Confirm Button Settings")]
    public Color confirmColor;
    public Sprite confirmIcon;

    [Header("Decline Button Settings")]
    public Color declineColor;
    public Sprite declineIcon;

    [Header("Warning Button Settings")]
    public Color warningColor;
    public Sprite warningSprite;

}
