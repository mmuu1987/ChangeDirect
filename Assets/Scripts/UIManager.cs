using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public SettingManager SettingManager;


    public static UIManager Instance;

    public GameObject PrefaGameObject;

    public Transform Grid;

    private string _path;

    public List<Direct> types = new List<Direct>();

    public GameObject TipGameObject;

    public Button SureButton;
    private void Awake()
    {
        Instance = this;
    }
	void Start ()
	{
	   SettingManager = new SettingManager();
       SettingManager.Init();
	   Init();
        SureButton.onClick.AddListener((() =>
        {
            TipGameObject.SetActive(false);
        }));
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void Init()
    {

        foreach (Direct direct in types)
        {
            GameObject go = Instantiate(PrefaGameObject);

            go.transform.parent = Grid;

            ChangeItem item = go.GetComponent<ChangeItem>();

            item.SetType(direct);
        }

      
    }

    public void ShowTip(bool isChange)
    {

        TipGameObject.gameObject.SetActive(true);
        if (isChange)
        {
            TipGameObject.transform.Find("Text").GetComponent<Text>().text = "改名成功";
        }
        else
        {
            TipGameObject.transform.Find("Text").GetComponent<Text>().text = "改名失败";
        }
    }
    /// <summary>
    /// 打开项目
    /// </summary>
    public string OpenProject()
    {
        OpenFileDlg pth = new OpenFileDlg();
        pth.structSize = Marshal.SizeOf(pth);
        pth.filter = "All files (*.*)|*.*";
        pth.file = new string(new char[256]);
        pth.maxFile = pth.file.Length;
        pth.fileTitle = new string(new char[64]);
        pth.maxFileTitle = pth.fileTitle.Length;
        pth.initialDir = Application.dataPath.Replace("/", "\\") + "\\Resources"; //默认路径
        pth.title = "打开项目";
        pth.defExt = "dat";
        pth.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
        if (OpenFileDialog.GetOpenFileName(pth))
        {
            string filepath = pth.file; //选择的文件路径;  
            return filepath;
        }
        return null;
    }

}
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class OpenFileDlg : ChinarFileDlog
{
}

public class OpenFileDialog
{
    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName([In, Out] OpenFileDlg ofd);
}

public class SaveFileDialog
{
    [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern bool GetSaveFileName([In, Out] SaveFileDlg ofd);
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class SaveFileDlg : ChinarFileDlog
{
}

/// <summary>
/// 文件日志类
/// </summary>
// [特性(布局种类.有序,字符集=字符集.自动)]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class ChinarFileDlog
{
    public int structSize = 0;
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public String filter = null;
    public String customFilter = null;
    public int maxCustFilter = 0;
    public int filterIndex = 0;
    public String file = null;
    public int maxFile = 0;
    public String fileTitle = null;
    public int maxFileTitle = 0;
    public String initialDir = null;
    public String title = null;
    public int flags = 0;
    public short fileOffset = 0;
    public short fileExtension = 0;
    public String defExt = null;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public String templateName = null;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int reservedInt = 0;
    public int flagsEx = 0;
}
