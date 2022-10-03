using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button), typeof(Image))]
public class FlexibleUIButton : FlexibleUI
{
    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning
    }

    private Image icon;
    private Image image;
    private Button button;

    [SerializeField]
    private ButtonType buttonType;   

    public override void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        icon = transform.Find("Icon").GetComponent<Image>();

        base.Awake();
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();     

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;

        button.spriteState = skinData.spriteState;

        SetButtonType();
    }

    void SetButtonType()
    {
        switch (buttonType)
        {
            case ButtonType.Confirm:
                image.color = skinData.confirmColor;
                icon.sprite = skinData.confirmIcon;
                break;
            case ButtonType.Decline:
                image.color = skinData.declineColor;
                icon.sprite = skinData.declineIcon;
                break;
            case ButtonType.Warning:
                image.color = skinData.warningColor;
                icon.sprite = skinData.warningSprite;
                break;
            default:
                image.color = skinData.defaultColor;
                icon.sprite = skinData.defaultIcon;
                break;
        }
    }
}
