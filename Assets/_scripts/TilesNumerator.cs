using TMPro;
using UnityEngine;

[ExecuteAlways]
public class TilesNumerator : MonoBehaviour
{
    TextMeshPro _name;
    Vector2Int _coords = new Vector2Int();

    void Start()
    {
        _name = GetComponent<TextMeshPro>();
        NumsView();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            NumsView();
            NamesUpdate();
        }
    }

    void NumsView()
    {
        _coords.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        _coords.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        _name.text = _coords.x + ", " + _coords.y;
    }

    void NamesUpdate()
    {
        transform.parent.name = _coords.ToString();
    }
}
