namespace ET.Server
{

    [EntitySystemOf(typeof(RechargeComponent))]
    [FriendOf(typeof(RechargeComponent))]
    public static partial class RechargeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RechargeComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this RechargeComponent self)
        {

        }
        
        
        public static void OnLogin(this RechargeComponent self)
        {
            NumericComponentServer numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentServer>();

        }
    }

}