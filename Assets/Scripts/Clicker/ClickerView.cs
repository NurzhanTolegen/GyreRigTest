using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClickerView : MonoBehaviour {
    public Button button;
    public TMP_Text label;

    public void AddListener(UnityAction action) {
        button.onClick.AddListener(action);
    }

    public void SetCount(int count) {
        label.text = count.ToString();
    }
}
