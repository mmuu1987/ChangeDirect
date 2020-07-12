using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeItem : MonoBehaviour
{


    public Button ChangeButton;

    public Text tip;

    public Text InputText;

    public Direct DirType;

	// Use this for initialization
	void Start () {
		ChangeButton.onClick.AddListener((() =>
		{
            string dirName = InputText.text;

            if (!string.IsNullOrEmpty(dirName))
            {
               bool isChange =  UIManager.Instance.SettingManager.ChangeDirectName(DirType, dirName);

                UIManager.Instance.ShowTip(isChange);
            }
            tip.text =   UIManager.Instance.SettingManager.GetPath(DirType);
		}));
        tip.text =  UIManager.Instance.SettingManager.GetPath(DirType);
	}

    public void SetType(Direct typeDirect)
    {
        DirType = typeDirect;
    }
}
