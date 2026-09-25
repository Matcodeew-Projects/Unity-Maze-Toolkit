//using System.Diagnostics;
using UnityEngine.UIElements;
using UnityEngine;

public class GridSettings
{
    private readonly MazeEditorContext context;
    private readonly VisualElement root;

    private IntegerField widthField;
    private IntegerField heightField;

    private Button createGridButton;

    public GridSettings(MazeEditorContext context, VisualElement root)
    {
        this.context = context;
        this.root = root;

        // Récupération des éléments du UXML
        widthField = root.Q<IntegerField>("WidthIntegerField");
        heightField = root.Q<IntegerField>("HeightIntegerField");
        createGridButton = root.Q<Button>("CreateGridButton");

        // Valeurs initiales
        widthField.value = context.Width;
        heightField.value = context.Height;

        // Events
        widthField.RegisterValueChangedCallback(OnWidthFieldChanged);
        heightField.RegisterValueChangedCallback(OnHeightFieldChanged);

        createGridButton.clicked += OnCreateGridButtonPressed;
    }

    private void OnWidthFieldChanged(ChangeEvent<int> evt)
    {
        context.Width = evt.newValue;
    }

    private void OnHeightFieldChanged(ChangeEvent<int> evt)
    {
        context.Height = evt.newValue;
    }

    private void OnCreateGridButtonPressed()
    {
        Debug.Log("Button pressed");

        context.Width = widthField.value;
        context.Height = heightField.value;
        context.UpdateCellsArrays();
        context.Push();
    }
}