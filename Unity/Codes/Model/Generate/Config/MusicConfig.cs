using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class MusicConfigCategory : ProtoObject
    {
        public static MusicConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, MusicConfig> dict = new Dictionary<int, MusicConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<MusicConfig> list = new List<MusicConfig>();
		
        public MusicConfigCategory()
        {
            Instance = this;
        }
		
        public override void EndInit()
        {
            foreach (MusicConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public MusicConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MusicConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MusicConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MusicConfig> GetAll()
        {
            return this.dict;
        }

        public MusicConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class MusicConfig: ProtoObject, IConfig
	{
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(2)]
		public int SampleSize { get; set; }
		[ProtoMember(3)]
		public int SpectRangeMin { get; set; }
		[ProtoMember(4)]
		public int SpectRangeMax { get; set; }
		[ProtoMember(5)]
		public double tensityMultiply { get; set; }
		[ProtoMember(6)]
		public double beatThreshold { get; set; }

	}
}
