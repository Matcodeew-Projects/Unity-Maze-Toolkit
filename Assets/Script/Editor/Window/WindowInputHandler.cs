using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GridInputHandler
{
    public event Action<Vector2> OnMouseDown;
    public event Action<Vector2> OnMouseUp;
    public event Action<Vector2> OnMouseDrag;
    public event Action<Vector2> OnScroll;

    private readonly VisualElement target;

    public GridInputHandler(VisualElement target)
    {
        this.target = target;

        target.RegisterCallback<PointerDownEvent>(HandlePointerDown);
        target.RegisterCallback<PointerUpEvent>(HandlePointerUp);
        target.RegisterCallback<PointerMoveEvent>(HandlePointerMove);
        target.RegisterCallback<WheelEvent>(HandleScroll);
    }

    private void HandlePointerDown(PointerDownEvent e)
    {
        Debug.Log($"Mouse Down : {e.position}");

        OnMouseDown?.Invoke(e.localPosition);
    }

    private void HandlePointerUp(PointerUpEvent e)
    {
        Debug.Log($"Mouse Up : {e.position}");

        OnMouseUp?.Invoke(e.localPosition);
    }

    private void HandlePointerMove(PointerMoveEvent e)
    {
        if (e.pressedButtons == 0)
            return;

        Debug.Log($"Mouse Drag : {e.position}");

        OnMouseDrag?.Invoke(e.localPosition);
    }

    private void HandleScroll(WheelEvent e)
    {
        Debug.Log($"Scroll : {e.delta}");

        OnScroll?.Invoke(e.delta);
    }
}