using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;


/// <summary>
/// 设置管理，包含一些保存到本地的文件夹名字
/// </summary>
public class SettingManager
{

    public Setting Setting;

    /// <summary>
    /// 执行程序的路径
    /// </summary>
    public string Path;

    public void Init()
    {
        string path = Application.dataPath;//

        DirectoryInfo dif = new DirectoryInfo(path);

        DirectoryInfo temp = dif.Parent.Parent;//得到了母程序StreamingAssets文件夹所在的路径

        Path = @"F:\WZS_FILE\gitHub\MyInteractionWall\unity-photo-particle-system-master\Assets\StreamingAssets";
        Debug.LogError(temp);
       // Path = temp.FullName;
        Setting = new Setting();
        LoadDirectInfo();

    }


    /// <summary>
    /// 获取可执行程序路径
    /// </summary>
    public string GetExePath(Direct type)
    {
        DirectoryInfo dif = null;
        switch (type)
        {
            case Direct.None:
                break;
            case Direct.FirstDir:
                dif = new DirectoryInfo(Setting.FirstDir);
                return dif.Name;
            case Direct.SecondDir:
                dif = new DirectoryInfo(Setting.SecondDir);
                return dif.Name;
            case Direct.ThirdDir:
                dif = new DirectoryInfo(Setting.ThirdDir);
                return dif.Name;
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }
        return Setting.ExePath;
    }
    /// <summary>
    /// 设置可执行程序的路径
    /// </summary>
    public void SetExePath(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            Setting.ExePath = path;

        }
        else
        {
            Debug.LogError("路径为Null");
        }
    }
    /// <summary>
    /// 加载文件夹信息
    /// </summary>
    public void LoadDirectInfo()
    {
        if (string.IsNullOrEmpty(Path)) return;
        string path = Path + "/Setting.data";

        if (!File.Exists(path))//不包含则创建，那就是游戏安装的时候第一次运行
        {
            string data = JsonUtility.ToJson(Setting);

            byte[] bytes = Encoding.UTF8.GetBytes(data);

            File.WriteAllBytes(path, bytes);
        }
        else
        {
            byte[] bytes = File.ReadAllBytes(path);

            string data = Encoding.UTF8.GetString(bytes);

            Setting = JsonUtility.FromJson<Setting>(data);
        }
    }

    public void SaveDirectInfo()
    {
        if (string.IsNullOrEmpty(Path)) return;

        string path = Path + "/Setting.data";

        string data = JsonUtility.ToJson(Setting);

        byte[] bytes = Encoding.UTF8.GetBytes(data);

        File.WriteAllBytes(path, bytes);
    }

    /// <summary>
    /// 改变文件夹名字
    /// </summary>
    public void ChangeDirectName(Direct type, string directName)
    {
        string path = null;
        DirectoryInfo dif;
        string newPath;
        switch (type)
        {
            case Direct.None:
                break;
            case Direct.FirstDir:
                dif = new DirectoryInfo(Setting.FirstDir);
                newPath = dif.Parent + "/" + directName;
                Directory.Move(dif.FullName, newPath);
                Setting.FirstDir = newPath;

                break;
            case Direct.SecondDir:
                dif = new DirectoryInfo(Setting.SecondDir);
                newPath = dif.Parent + "/" + directName;
                Directory.Move(dif.FullName, newPath);
                Setting.SecondDir = newPath;
                break;
            case Direct.ThirdDir:
                dif = new DirectoryInfo(Setting.ThirdDir);
                newPath = dif.Parent + "/" + directName;
                Directory.Move(dif.FullName, newPath);
                Setting.ThirdDir = newPath;
                break;
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }




        SaveDirectInfo();
    }

    private void ChangeDirectName(string path, string directName)
    {
        DirectoryInfo dif = new DirectoryInfo(path);

        string newPath = dif.Parent + "/" + directName;

        Directory.Move(dif.FullName, newPath);


        Debug.Log("改名成功");
    }

}

public class Setting
{
    /// <summary>
    /// 大事件的第一层文件夹名字路径
    /// </summary>
    public string FirstDir;
    /// <summary>
    /// 大事件的第一层文件夹名字路径
    /// </summary>
    public string SecondDir;
    /// <summary>
    /// 大事件的第一层文件夹路径
    /// </summary>
    public string ThirdDir;

    /// <summary>
    /// 执行文件的路径
    /// </summary>
    public string ExePath;

    public Setting()
    {
        FirstDir = "2001-2009";
        SecondDir = "2010-2019";
        ThirdDir = "2020";
    }


}

public enum Direct
{
    None,
    FirstDir,
    SecondDir,
    ThirdDir
}
