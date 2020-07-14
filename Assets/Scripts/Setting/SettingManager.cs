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
    /// <summary>
    /// 木程序的目录路径信息
    /// </summary>
    public DirectoryInfo ParentInfo;

    public void Init()
    {
        string path = Application.dataPath;//

        DirectoryInfo dif = new DirectoryInfo(path);

        ParentInfo = dif.Parent.Parent;//得到了母程序StreamingAssets文件夹所在的路径

       // Path = @"E:\WB\MyInteracionWall\MyInteractionWall\unity-photo-particle-system-master\Assets\StreamingAssets";
      //  Debug.LogError(temp);
         Path = ParentInfo.FullName;
    
        LoadDirectInfo();

    }


    /// <summary>
    /// 获取可执行程序路径
    /// </summary>
    public string GetPath(Direct type,bool isParent=false)
    {
        DirectoryInfo dif = null;
        switch (type)
        {
            case Direct.None:
                break;
            case Direct.FirstDir:
                dif = new DirectoryInfo(ParentInfo+"/"+Setting.FirstDir);
                break;
            case Direct.SecondDir:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.SecondDir);
                break;
            case Direct.ThirdDir:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.ThirdDir);
                
                break;
            case Direct.IcOne:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.IcOne);
                break;
            case Direct.IcTwo:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.IcTwo);
                break;
            case Direct.IcThree:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.IcThree);
                break;
            case Direct.IcFour:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.IcFour);
                break;
            case Direct.IcFive:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.IcFive);
                break;
            case Direct.IcSix:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.IcSix);
                break;
            case Direct.PhOne:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.PhOne);
                break;
            case Direct.PhTwo:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.PhTwo);
                break;
            case Direct.PhThree:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.PhThree);
                break;
            case Direct.OsOne:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.OsOne);
                break;
            case Direct.OsTwo:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.OsTwo);
                break;
            case Direct.OsThree:
                dif = new DirectoryInfo(ParentInfo + "/" + Setting.OsThree);
                break;
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }
        if (dif != null)
        {
            return dif.Parent.Name + "目录下的：" + dif.Name;
        }
        return null;
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
            Setting = new Setting();

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

    public bool SaveDirectInfo()
    {
        if (string.IsNullOrEmpty(Path)) return false;

        string path = Path + "/Setting.data";

        string data = JsonUtility.ToJson(Setting);

        byte[] bytes = Encoding.UTF8.GetBytes(data);

        File.WriteAllBytes(path, bytes);

        return true;
    }

    /// <summary>
    ///  改变文件夹名字
    /// </summary>
    /// <param name="type">需要改变的类型</param>
    /// <param name="directName">改成后的文件夹名字</param>
    public bool ChangeDirectName(Direct type, string directName)
    {
        bool isChange = false;
        switch (type)
        {
            case Direct.None:
                break;
            case Direct.FirstDir:

                Setting.FirstDir = ChangeDirectName(directName, Setting.FirstDir);
                break;
            case Direct.SecondDir:
                Setting.SecondDir = ChangeDirectName(directName, Setting.SecondDir); 
                break;
            case Direct.ThirdDir:
                Setting.ThirdDir = ChangeDirectName(directName, Setting.ThirdDir); 
                break;
            case Direct.IcOne:
                Setting.IcOne = ChangeDirectName(directName, Setting.IcOne); 
                break;
            case Direct.IcTwo:
                Setting.IcTwo = ChangeDirectName(directName, Setting.IcTwo); 
                break;
            case Direct.IcThree:
                Setting.IcThree = ChangeDirectName(directName, Setting.IcThree); 
                break;
            case Direct.IcFour:
                Setting.IcFour = ChangeDirectName(directName, Setting.IcFour); 
                break;
            case Direct.IcFive:
                Setting.IcFive = ChangeDirectName(directName, Setting.IcFive); 
                break;
            case Direct.IcSix:
                Setting.IcSix = ChangeDirectName(directName, Setting.IcSix); 
                break;
            case Direct.PhOne:
                Setting.PhOne = ChangeDirectName(directName, Setting.PhOne); 
                break;
            case Direct.PhTwo:
                Setting.PhTwo = ChangeDirectName(directName, Setting.PhTwo); 
                break;
            case Direct.PhThree:
                Setting.PhThree = ChangeDirectName(directName, Setting.PhThree); 
                break;
            case Direct.OsOne:
                Setting.OsOne = ChangeDirectName(directName, Setting.OsOne); 
                break;
            case Direct.OsTwo:
                Setting.OsTwo = ChangeDirectName(directName, Setting.OsTwo); 
                break;
            case Direct.OsThree:
                Setting.OsThree = ChangeDirectName(directName, Setting.OsThree); 
                break;
            default:
                throw new ArgumentOutOfRangeException("type", type, null);
        }


       isChange = SaveDirectInfo();

        return isChange;
    }

    private string  ChangeDirectName(string directName,string path)
    {

        var dif = new DirectoryInfo(ParentInfo+"/"+path);
        string oldName = dif.Name;

        if (directName == oldName) return dif.FullName;
        string  newPath = dif.Parent + "/" + directName;
        Directory.Move(dif.FullName, newPath);
        return dif.Parent.Name+"/"+directName;
    }

}

public class Setting
{
    /// <summary>
    /// 大事件的第一层文件夹路径
    /// </summary>
    public string FirstDir;
    /// <summary>
    /// 大事件的第一层文件夹路径
    /// </summary>
    public string SecondDir;
    /// <summary>
    /// 大事件的第一层文件夹路径
    /// </summary>
    public string ThirdDir;
    /// <summary>
    /// 公司介绍里面的的第1栏
    /// </summary>
    public string IcOne;
    /// <summary>
    /// 公司介绍里面的的第2栏
    /// </summary>
    public string IcTwo;
    /// <summary>
    /// 公司介绍里面的的第3栏
    /// </summary>
    public string IcThree;
    /// <summary>
    /// 公司介绍里面的的第4栏
    /// </summary>
    public string IcFour;
    /// <summary>
    /// 公司介绍里面的的第5栏
    /// </summary>
    public string IcFive;
    /// <summary>
    /// 公司介绍里面的的第6栏
    /// </summary>
    public string IcSix;

    /// <summary>
    /// 私享穿甲第1栏
    /// </summary>
    public string PhOne;

    /// <summary>
    /// 私享穿甲第2栏
    /// </summary>
    public string PhTwo;
    /// <summary>
    /// 私享穿甲第3栏
    /// </summary>
    public string PhThree;

    /// <summary>
    /// 卓越风采第1栏
    /// </summary>
    public string OsOne;
    /// <summary>
    /// 卓越风采第2栏
    /// </summary>
    public string OsTwo;
    /// <summary>
    /// 卓越风采第3栏
    /// </summary>
    public string OsThree;


    public Setting()
    {
        FirstDir = "/大事记/2001-2009";
        SecondDir =  "/大事记/2010-2019";
        ThirdDir =  "/大事记/2020";

        IcOne = "/公司介绍/集团介绍";
        IcTwo =  "/公司介绍/基本信息";
        IcThree =  "/公司介绍/股东概况";
        IcFour =  "/公司介绍/荣誉奖项";
        IcFive =  "/公司介绍/产品体系";
        IcSix =  "/公司介绍/服务体系";

        PhOne =  "/私享传家/品牌介绍";
        PhTwo = "/私享传家/尊享服务";
        PhThree =  "/私享传家/大湾区高净值中心";

        OsOne =  "/卓越风采/MDRT荣誉榜";
        OsTwo =  "/卓越风采/2020年MDRT达标榜";
        OsThree = "/卓越风采/双百万储备力量";
    }


}

public enum Direct
{
    None,
    FirstDir,
    SecondDir,
    ThirdDir,
    IcOne,
    IcTwo,
    IcThree,
    IcFour,
    IcFive,
    IcSix,
    PhOne,
    PhTwo,
    PhThree,
    OsOne,
    OsTwo,
    OsThree

}
