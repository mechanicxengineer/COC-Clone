using UnityEngine;

public class BuildGrid : MonoBehaviour
{
    private int _rows = 45;
    private int _colums = 45;
    private float _cellSize = 1f;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i <= _rows; i++)
        {
            Vector3 point = transform.position + transform.forward.normalized * _cellSize * (float)i;
            Gizmos.DrawLine(point, point + transform.right.normalized * _cellSize * (float)_colums);
        }
        for (int i = 0; i <= _colums; i++)
        {
            Vector3 point = transform.position + transform.right.normalized * _cellSize * (float)i;
            Gizmos.DrawLine(point, point + transform.forward.normalized * _cellSize * (float)_rows);
        }
    }
#endif
}