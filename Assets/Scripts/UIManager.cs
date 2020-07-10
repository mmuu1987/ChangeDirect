using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private SettingManager _settingManager;

   
    public Button FirstDir;

    public Button SecondDir;

    public Button ThirdDir;


    private string _path;
	void Start ()
	{
	   _settingManager = new SettingManager();
       _settingManager.Init();
       
        FirstDir.onClick.AddListener((() =>
        {
            string dirName = FirstDir.transform.parent.Find("Text").GetComponent<Text>().text;

            if (!string.IsNullOrEmpty(dirName))
            {
                _settingManager.ChangeDirectName(Direct.FirstDir, dirName);
            }
            FirstDir.transform.parent.Find("tip").GetComponent<Text>().text = "当前大事件第一层文件夹的名字为：   " + _settingManager.GetExePath(Direct.FirstDir);
        }));
	    FirstDir.transform.parent.Find("tip").GetComponent<Text>().text = "当前大事件第一层文件夹的名字为：   " + _settingManager.GetExePath(Direct.FirstDir);

        SecondDir.onClick.AddListener((() =>
        {
            string dirName = SecondDir.transform.parent.Find("Text").GetComponent<Text>().text;

            if (!string.IsNullOrEmpty(dirName))
            {
                _settingManager.ChangeDirectName(Direct.SecondDir, dirName);
            }
            SecondDir.transform.parent.Find("tip").GetComponent<Text>().text = "当前大事件第二层文件夹的名字为：   " + _settingManager.GetExePath(Direct.SecondDir);
        }));
        SecondDir.transform.parent.Find("tip").GetComponent<Text>().text = "当前大事件第二层文件夹的名字为：   " + _settingManager.GetExePath(Direct.SecondDir);


        ThirdDir.onClick.AddListener((() =>
        {
            string dirName = ThirdDir.transform.parent.Find("Text").GetComponent<Text>().text;

            if (!string.IsNullOrEmpty(dirName))
            {
                _settingManager.ChangeDirectName(Direct.ThirdDir, dirName);
            }
            ThirdDir.transform.parent.Find("tip").GetComponent<Text>().text = "当前大事件第三层文件夹的名字为：   " + _settingManager.GetExePath(Direct.ThirdDir);
        }));
        ThirdDir.transform.parent.Find("tip").GetComponent<Text>().text = "当前大事件第三层文件夹的名字为：   " + _settingManager.GetExePath(Direct.ThirdDir);
	}
	
	// Update is called once per frame
	void Update () {
		
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
