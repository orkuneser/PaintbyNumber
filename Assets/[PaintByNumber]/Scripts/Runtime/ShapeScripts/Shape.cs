using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour, IClickable
{
    public int shapeNumber;

    private ShapeTextController _shapeTextController;
    private ShapeTextController ShapeTextController => _shapeTextController == null ? _shapeTextController = GetComponent<ShapeTextController>() : _shapeTextController;

    private void OnEnable()
    {
        EventManager.OnSelectColor.AddListener(CheckState);
    }

    private void OnDisable()
    {
        EventManager.OnSelectColor.RemoveListener(CheckState);
    }

    private void OnMouseDown()
    {
        ClickAction();
    }

    private void CheckState()
    {
        if (Painter.Instance.selectedNumber == shapeNumber)
        {
            ShapeTextController.ChangeColor(Color.red);
        }
        else
        {
            ShapeTextController.ChangeColor(Color.white);
        }
    }

    public void ClickAction()
    {
        if (Painter.Instance.selectedNumber == shapeNumber)
        {
            ShapeTextController.CloseTextMesh();
            GetComponent<SpriteRenderer>().DOColor(Painter.Instance.selectedColor, 1f);
        }
    }
}
