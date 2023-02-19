using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ShapeTextController : MonoBehaviour
{
    private TextMeshPro _shapeTextMesh;
    private TextMeshPro ShapeTextMesh => _shapeTextMesh == null ? _shapeTextMesh = GetComponentInChildren<TextMeshPro>() : _shapeTextMesh;

    private Shape _shape;
    private Shape Shape => _shape == null ? _shape = GetComponent<Shape>() : _shape;

    private void Start()
    {
        UpdateTextMesh();
    }

    private void UpdateTextMesh()
    {
        ShapeTextMesh.SetText(Shape.shapeNumber.ToString());
    }

    public void ChangeColor(Color color)
    {
        ShapeTextMesh.color = color;
    }

    public void CloseTextMesh()
    {
        ShapeTextMesh.gameObject.SetActive(false);
    }
}
