using System;
using UnityEditorInternal;
using UnityEngine;

[Serializable]
public class Cell
{
    [SerializeField] private Vector2Int position;
    [SerializeField] private CellType type;

    public Vector2Int Position => position;
    public CellType Type => type;

    public Cell(Vector2Int position, CellType type = CellType.Empty)
    {
        this.position = position;
    }

    public void SetType(CellType newType)
    {
        type = newType;
    }
}