using System;
using System.Collections.Generic;
using UnityEngine;
public class MazeEditorContext
{
    public event Action<MazeEditorContext> OnContextPushed;
    public void Push()
    {
        OnContextPushed?.Invoke(this);
    }

    public int Width { get; set; }
    public int Height { get; set; }

    public float CellSize { get; set; }

    public Cell[,] Cells { get; private set; }

    public CellType CurrentTypeSelected { get; set; } = CellType.Wall;

    public MazeEditorContext(int width, int height, float cellSize)
    {
        Width = width;
        Height = height;
        CellSize = cellSize;
        UpdateCellsArrays();
    }

    public void UpdateCellsArrays()
    {
        Cells = new Cell[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Cells[x, y] = new Cell(
                    new Vector2Int(x, y),
                    CellType.Empty
                );
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        return Cells[x, y];
    }
}
