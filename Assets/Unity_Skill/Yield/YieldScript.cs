using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldScript : MonoBehaviour
{
    //public int TestCase;
    public enum yield_return_Type {non, WaitForEndOfFrame, WaitForSeconds, WaitForFrame }
    public yield_return_Type yield_Return_Type;
    private IEnumerator Start() {//start 返回迭代器直接可以开启协程
        
        switch (yield_Return_Type)
        {
            case yield_return_Type.non:
                //$ 特殊字符将字符串文本标识为  内插字符串 。
                //内插字符串是可能包含内插表达式的字符串文本 。
                //将内插字符串解析为结果字符串时，带有内插表达式的项会替换为表达式结果的字符串表示形式。
                Debug.Log($"开启协程等待前 当前帧{Time.frameCount}");
                yield return null;
                Debug.Log($"开启协程等待后 当前帧{Time.frameCount}");
                break;
            case yield_return_Type.WaitForEndOfFrame:
                yield return new WaitForEndOfFrame();//每次使用WaitForEndOfFrame都要实例化,占用资源
                Debug.Log($"yield return EndOfFram第一次 当前帧{Time.frameCount}");
                yield return YieldHelper.WaitForEndOfFrame;//只实例化一次,在静态类中反复调用即可
                Debug.Log($"yield return EndOfFram第一次 当前帧{Time.frameCount}");
                yield return YieldHelper.WaitForEndOfFrame;
                Debug.Log($"yield return EndOfFram第一次 当前帧{Time.frameCount}");

                break;
            case yield_return_Type.WaitForSeconds:
                Debug.Log($"before 当前时间{Time.time}");
                yield return YieldHelper.WaitForSeconds(0.5f);//调用静态方法,传入参数节省实例化次数
                Debug.Log($"before 当前时间{Time.time}");
                yield return YieldHelper.WaitForSeconds(0.5f);
                Debug.Log($"before 当前时间{Time.time}");
                break;
            case yield_return_Type.WaitForFrame:
                yield return null;
                Debug.Log($"yield return null 当前帧{Time.frameCount}");
                yield return 0;
                Debug.Log($"yield return 0 当前帧{Time.frameCount}");
                yield return 100;//不管返回几,都是只等待1帧
                Debug.Log($"yield return 100 当前帧{Time.frameCount}");
                yield return YieldHelper.WaitForFrame(3);//实例化一个"yield return null;",执行N次,达到等待N帧的效果
                Debug.Log($"yield return YieldHelper.WaitForFrame 当前帧{Time.frameCount}");
                break;
            default:
                break;
        }
    }
}
public static   class YieldHelper
{
    public static WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();

    public static IEnumerator WaitForSeconds(float totalTime,bool ignoreTimeScale=false)
    {
        float time = 0;
        while (time<totalTime)
        {
            time += (ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
            yield return null;
        }
    }
    public static IEnumerator WaitForFrame(int frame)
    {
        int count = 0;
        while (count< frame)
        {
            yield return null;
            count++;
        }
    }
}
