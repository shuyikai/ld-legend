namespace ET.Client
{
    public static class ActivityTipHelper
    {
        //竞技场
        public static async ETTask<int> RequestEnterArena(Scene root)
        {
            int sceneId = 6000001;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            int sceneType = sceneConfig.MapType;
            if (sceneType != MapTypeEnum.Arena)
            {
                return ErrorCode.ERR_Error;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);

            int errorCode = await EnterMapHelper.RequestTransfer(root, sceneType, sceneId);
            return errorCode;
        }
    }
}