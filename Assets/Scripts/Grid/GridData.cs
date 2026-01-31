using UnityEngine;

[CreateAssetMenu(fileName = "GridData", menuName = "Scriptable Objects/Grid/Grid")]
public class GridData : ScriptableObject
{
    [Header("Personal")]
    public int width;
    public int height;

    [Header("In global world")]
    public float cellSize;
    public Vector3 originPosition;
}
