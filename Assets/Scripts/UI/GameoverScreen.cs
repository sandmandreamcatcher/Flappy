﻿using UnityEngine.Events;

public class GameoverScreen : Screen
{
    public event UnityAction RestartButtonClick;
    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }
}