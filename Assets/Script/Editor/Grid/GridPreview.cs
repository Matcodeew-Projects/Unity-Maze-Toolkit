using UnityEngine;
using UnityEngine.UIElements;

public class GridPreview
{
    private readonly MazeEditorContext context;

    private readonly VisualElement root;

    private readonly VisualElement gridBackground;
    private readonly Label zoomLabel;

    private GridInputHandler inputHandler;
    private GridController gridController;


    public GridPreview(VisualElement root, MazeEditorContext context)
    {
        this.root = root;
        this.context = context;

        context.OnContextPushed += OnContextChanged;

        gridBackground =
            root.Q<VisualElement>("GridPreviewBackground");

        inputHandler = new GridInputHandler(gridBackground);


        gridController = new GridController(context);
        inputHandler.OnMouseDown += gridController.MouseToCell;

        zoomLabel =
            root.Q<Label>("ZoomLabel");

        gridBackground.generateVisualContent += DrawGrid;


        UpdateZoomLabel();
    }

    private void UpdateZoomLabel()
    {
        // exemple
        // zoomLabel.text = $"{context.Zoom * 100:F0}%";
        float zoom = 100;
        zoomLabel.text = $"zoom : {zoom}%";
    }

    private void OnContextChanged(MazeEditorContext context)
    {
        gridBackground.MarkDirtyRepaint();
    }

    private void DrawGrid(MeshGenerationContext meshContext)
    {
        Painter2D painter = meshContext.painter2D;

        // Dessine les cellules
        for (int x = 0; x < context.Width; x++)
        {
            for (int y = 0; y < context.Height; y++)
            {
                Cell cell = context.GetCell(x, y);

                Color color = GetCellTypeColor(cell.Type);

                float posX = x * context.CellSize;
                float posY = y * context.CellSize;

                painter.fillColor = color;

                painter.BeginPath();
                painter.MoveTo(new Vector2(posX, posY));
                painter.LineTo(new Vector2(posX + context.CellSize, posY));
                painter.LineTo(new Vector2(posX + context.CellSize, posY + context.CellSize));
                painter.LineTo(new Vector2(posX, posY + context.CellSize));
                painter.ClosePath();

                painter.Fill();
            }
        }

        // Dessine les lignes par-dessus
        painter.strokeColor = Color.gray;
        painter.lineWidth = 1f;

        float width = context.Width * context.CellSize;
        float height = context.Height * context.CellSize;

        for (int x = 0; x <= context.Width; x++)
        {
            float posX = x * context.CellSize;

            painter.BeginPath();
            painter.MoveTo(new Vector2(posX, 0));
            painter.LineTo(new Vector2(posX, height));
            painter.Stroke();
        }

        for (int y = 0; y <= context.Height; y++)
        {
            float posY = y * context.CellSize;

            painter.BeginPath();
            painter.MoveTo(new Vector2(0, posY));
            painter.LineTo(new Vector2(width, posY));
            painter.Stroke();
        }
    }

    private Color GetCellTypeColor(CellType type)
    {
        return type switch
        {
            CellType.Spawn => Color.green,
            CellType.Wall => Color.black,
            CellType.Floor => Color.gray,
            _ => Color.white
        };
    }
}