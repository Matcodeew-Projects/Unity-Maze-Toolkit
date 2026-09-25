using UnityEngine;

public class GridController
{
    MazeEditorContext context;
    public GridController(MazeEditorContext context)
    {
        this.context = context;
    }


    public void MouseToCell(Vector2 mousePosition)
    {
        Vector2Int cellPos = new Vector2Int(
            Mathf.FloorToInt(mousePosition.x / context.CellSize),
            Mathf.FloorToInt(mousePosition.y / context.CellSize)
        );

        if (cellPos.x < 0 || cellPos.x >= context.Width ||
            cellPos.y < 0 || cellPos.y >= context.Height)
        {
            return;
        }

        context.Cells[cellPos.x, cellPos.y]
            .SetType(context.CurrentTypeSelected);

        context.Push();
    }
}