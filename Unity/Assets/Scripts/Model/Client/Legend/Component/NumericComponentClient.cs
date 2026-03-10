using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Client
{
    [FriendOf(typeof(NumericComponentClient))]
    public static class NumericComponentClientSystem
    {
        public static float GetAsFloat(this NumericComponentClient self, int numericType)
        {
            return (float)self.GetByKey(numericType) / 10000;
        }

        public static int GetAsInt(this NumericComponentClient self, int numericType)
        {
            return (int)self.GetByKey(numericType);
        }

        public static long GetAsLong(this NumericComponentClient self, int numericType)
        {
            return self.GetByKey(numericType);
        }

        public static long GetByKey(this NumericComponentClient self, int key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

        public static void ApplyValue(this NumericComponentClient self, int numericType, long value, bool notice = true, bool check = true,
        long attackid = 0, int skillId = 0, int damgeType = 0)
        {
            long old = self.GetByKey(numericType);

            self.NumericDic[numericType] = value;
            
            if (notice)
            {
                //发送改变属性的相关消息
                NumbericChange args = new NumbericChange();
                args.Defend = self.Parent as Unit;
                args.AttackId = attackid;
                args.NumericType = numericType;
                args.OldValue = old;
                args.NewValue = self.NumericDic[numericType];
                args.SkillId = skillId;
                args.DamgeType = damgeType;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
        }

        /// <summary>
        /// 传入改变值,设置当前的属性值, 不走公式
        /// </summary>
        /// <param name="self"></param>
        /// <param name="attackId"></param>
        /// <param name="numericType"></param>
        /// <param name="value"></param>
        /// <param name="skillID"></param>
        /// <param name="notice"></param>
        /// <param name="damgeType"></param>
        public static void ApplyValue(this NumericComponentClient self, long attackId, int numericType, long value, int skillID, bool notice = true,
        int damgeType = 0)
        {
            //是否超过指定上限值
            long old = self.GetByKey(numericType);
            self.NumericDic[numericType] = value;
            
            if (notice)
            {
                //发送改变属性的相关消息
                NumbericChange args = new NumbericChange();
                args.Defend = self.Parent as Unit;
                args.AttackId = attackId;
                args.NumericType = numericType;
                args.OldValue = old;
                args.NewValue = self.NumericDic[numericType];
                args.SkillId = skillID;
                args.DamgeType = damgeType;
                EventSystem.Instance.Publish(self.Scene(), args);
            }
        }
    }

    [ComponentOf(typeof(Unit))]
    public class NumericComponentClient : Entity, IAwake, ITransfer
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> NumericDic = new();
    }
}