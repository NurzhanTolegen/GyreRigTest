using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerController : MonoBehaviour {

    private ClickerView clickerView;
    private ClickerModel clickerModel;

    void Start() {
        clickerView = GetComponent<ClickerView>();
        clickerModel = GetComponent<ClickerModel>();

        clickerView.AddListener(AddClick);
    }

    private void AddClick() {
        clickerModel.clickCount++;
        clickerView.SetCount(clickerModel.clickCount);
    }

}
