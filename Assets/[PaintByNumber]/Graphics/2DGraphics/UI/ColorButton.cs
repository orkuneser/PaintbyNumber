using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private Color _buttonColor;
    [SerializeField] private int _buttonNumber;

    private Button _button;
    private Button Button => _button == null ? _button = GetComponent<Button>() : _button;

    private TextMeshProUGUI _textMesh;
    private TextMeshProUGUI TextMesh => _textMesh == null ? _textMesh = GetComponentInChildren<TextMeshProUGUI>() : _textMesh;

    private const float PUNCH_STRENGTH = 0.075f;
    private const float PUNCH_TWEEN_DURATION = 0.25f;
    private string tweenID;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    private void Start()
    {
        UpdateTextMesh();
        tweenID = GetInstanceID() + "punchEffect";
    }

    private void OnClick()
    {
        PunchEffect();
        Painter.Instance.selectedColor = _buttonColor;
        Painter.Instance.selectedNumber = _buttonNumber;
        EventManager.OnSelectColor.Invoke();
    }

    private void UpdateTextMesh()
    {
        TextMesh.SetText(_buttonNumber.ToString());
    }

    private void PunchEffect()
    {
        DOTween.Complete(tweenID);
        transform.DOPunchScale(Vector3.one * PUNCH_STRENGTH, PUNCH_TWEEN_DURATION, 1).SetEase(Ease.Linear).SetId(tweenID);
    }
}
