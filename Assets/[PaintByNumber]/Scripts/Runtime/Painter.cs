using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    #region SINGLETON
    public static Painter Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Color selectedColor;
    public int selectedNumber;

    private void Start()
    {
        selectedColor = Color.white;
        selectedNumber = 0;
        EventManager.OnSelectColor.Invoke();
    }
}
