namespace Pool
{
    using UnityEngine;
    public class PoolDefine
    {
        public readonly static string poolRootName = "PoolsRoot";
        public static Transform mpool_Root;
        public static Transform pool_Root
        {
            get
            {
                if (mpool_Root == null)
                {
                    GameObject game = new GameObject(poolRootName);
                    Canvas canvas = game.AddComponent<Canvas>();
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                    mpool_Root = game.transform;
                    Object.DontDestroyOnLoad(mpool_Root);
                }
                return mpool_Root;
            }
        }
    }
}