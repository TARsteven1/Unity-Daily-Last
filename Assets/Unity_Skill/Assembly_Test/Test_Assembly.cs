//No Engine Reference勾选后就不能使用UnityEngine.dll
//using UnityEngine;


//Assembly Dedinition Reference后可以访问对应dll中的成员
using TMPro;

//添加Overidde Reference后可以访问对应dll中的成员,不勾选此项会加载所有的dll
using LitJson;
using NetWorkingAPI;



public class Test_Assembly /*: MonoBehaviour*/
{
    public TextMeshPro textMeshPro;
    public void Test()
    {
        PointsHandler.TestDll("XXX");
        textMeshPro.text="Overidde Reference后可以访问对应dll中的成员";
        data.Clear();
    }
    JsonData data = new JsonData();//写入json格式的数据


}
