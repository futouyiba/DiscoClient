﻿using System.Collections.Generic;
using UnityEngine;

namespace ET
{
	[ObjectSystem]
	public class UnitComponentAwakeSystem : AwakeSystem<UnitComponent>
	{
		public override void Awake(UnitComponent self)
		{
			self.NpcUnits = new Dictionary<long, Unit>();
			self.PlayerUnits = new Dictionary<int, Unit>();
		}
	}
	
	[ObjectSystem]
	public class UnitComponentDestroySystem : DestroySystem<UnitComponent>
	{
		public override void Destroy(UnitComponent self)
		{
		}
	}
	
	public static class UnitComponentSystem
	{
		public static void Add(this UnitComponent self, Unit unit)
		{
		}

		public static Unit Get(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			return unit;
		}

		public static void Remove(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			unit?.Dispose();
		}

		public static bool AddNpc(this UnitComponent self, Unit unit)
		{
			if (!self.NpcUnits.ContainsKey(unit.Id))
			{
				self.NpcUnits.Add(unit.Id, unit);
				return true;
			}

			return false;
		}

		public static bool RemoveNpc(this UnitComponent self, Unit unit)
		{
			if (self.NpcUnits.ContainsKey(unit.Id))
			{
				self.NpcUnits.Remove(unit.Id);
				return true;
			}

			return false;
		}

		public static bool AddPlayer(this UnitComponent self, Unit unit)
		{
			int playerId = unit.GetComponent<CharComp>().playerData.player_id;
			if (!self.PlayerUnits.ContainsKey(playerId))
			{
				self.PlayerUnits.Add(playerId, unit);
				return true;
			}

			return false;
		}

		public static bool RemovePlayer(this UnitComponent self, Unit unit)
		{
			int playerId = unit.GetComponent<CharComp>().playerData.player_id;
			if (self.PlayerUnits.ContainsKey(playerId))
			{
				self.PlayerUnits.Remove(playerId);
				return true;
			}

			return false;
		}
		
		public static bool RemovePlayer(this UnitComponent self, int playerId)
		{
			if (self.PlayerUnits.ContainsKey(playerId))
			{
				self.PlayerUnits.Remove(playerId);
				return true;
			}

			return false;
		}

		static string[] names = new string[]
        {
            "苹果脸", "瓜子脸", "鹅蛋脸", "长方脸", "四方脸", "俊美的脸", "丑陋的脸", "清瘦的脸", "满脸憔悴", "一脸稚气",
            "古铜色的脸", "黑里透红的脸", "红扑扑的脸", "布满皱纹的脸", "脸色苍白", "愁眉苦脸", "嬉皮笑脸", "面黄肌瘦", "满脸雀斑", "面如桃花", "面如土色", "天庭饱满",
            "脸颊绯红", "面目可憎", "油头粉面", "面不改色", "十指尖尖", "纤纤素手", "粗壮的大手", "身材矮小", "身材苗条", "身材丰腴", "体态轻盈", "身材臃肿", "佝偻着身子",
            "身强力壮", "虎背熊腰", "膀阔腰圆", "肌腱发达", "腰板挺直", "彪形大汉", "大腹便便", "脑满肠肥", "身材高挑", "亭亭玉立", "袅袅婷婷", "弱不禁风", "瘦骨嶙峋",
            "瘦骨如柴", "短小精悍", "朴素", "大方", "整洁", "时髦", "摩登", "讲究", "笔挺", "邋遢", "俗气", "穿戴整齐", "衣冠楚楚", "穿红戴绿", "衣着入时",
            "珠光宝气", "花枝招展", "衣衫不整", "不修边幅破破烂烂", "袒臂露肩", "衣不蔽体", "赤身裸体", "一丝不挂", "庄重", "端庄", "安闲", "安详", "恬静", "文雅",
            "镇静", "沉着", "诚挚", "憨厚", "恳切", "潇洒", "妩媚", "羞涩", "腼腆", "严厉", "冷酷", "坚毅", "傲慢", "疲惫", "沮丧", "失神", "诧异", "发愣",
            "尴尬", "踌躇", "容光焕发", "英姿勃勃", "精神矍铄", "精神抖擞", "生龙活虎", "威风凛凛", "英姿飒爽", "风度翩翩", "热情洋溢", "热情奔放", "温文尔雅文质彬彬",
            "和蔼可亲", "和颜悦色", "心平气和", "平心静气", "悠然自得", "毕恭毕敬从容不迫", "泰然自若", "津津有味", "若无其事", "不露声色", "面红耳赤", "面有赧颜无精打彩",
            "郁郁寡欢", "闷闷不乐", "局促不安", "垂头丧气", "精疲力竭", "风尘仆仆气喘吁吁", "呆若木鸡", "瞠目结舌", "哑口无言", "交头接耳", "笨头笨脑", "疯疯癫癫凶神恶煞",
            "杀气腾腾", "装腔作势", "盛气凌人", "龇牙咧嘴", "神气十足", "傲慢无礼神气活现", "趾高气扬", "咄咄逼人", "目空一切", "不屑一顾", "目中无人", "旁若无人冷眼旁观",
            "贼头贼脑", "鬼鬼祟祟", "半信半疑", "不知所措", "漫不经心", "心不在焉怅然若失", "垂涎三尺", "死皮赖脸", "缩手缩脚", "丑态百出", "沙眼", " 泪眼", " 睡眼",
            " 醉眼", "星眼", " 凤眼", " 杏眼", " 媚眼", " 猫眼", " 虎眼", " 美目", " 俊目", " 秀目", " 朗目", " 润目", " 星眸", " 慧眼", " 秋波",
            " 秋水", " ", "风泪眼", " 吊梢限", "杏儿眼", " 丹凤眼", " ", "圆溜溜", " 滴溜溜", " 骨碌碌", " 直勾勾", "乌溜溜", "目似闪电", " 双目议剑",
            " 双目如潭", " 双目灼灼", " 双目凛凛", "双目炯炯", " 双目传神", " 双目鸟黑", " 双目凝滞", " 双目晶莹", "双目失明", " 双目犀利", " 双目粼粼", " 二目凛凛",
            " 二目射光", "二目炯然", " 二目圆瞪", " 二目炯炯", " 两目如锥", " 两目如剑", "两眼墨墨", " 两眼灼灼", " 两阳如灯", " 两眼微突", " 两眼发呆", "两眼发愣",
            " 两眼直翻", " 两眼放光", " 两眼火亮", " 双眼赛灯", "两眸秋水", " 双眼直竖", " 双眼圆睁", " 双眸剪水", " 两目低垂", "两目焰焰", " 炯炯双目", " 虎目灼灼",
            " 秀目闪闪", " 凤目明澈", "眼如秋水", " 眼横秋水", " 眼似清泉", " 眼如星星", " 眼似铜铃", "眼似秋水", " 眼如丹凤", " 眼若饿鹰", " 睛若秋波", " 眼若流星",
            "怪眼如灯", " 杏眼如灯", " 环眼如豹", " 瞪目如灯", " 眼亮如星", "眸若清泉", " 眸清似水", " 目如悬珠", " 眼闪秋波", " 眼含秋波", "眼放光华", " 眼瞪如球",
            " 俊目电射", " 目似剑光", " 凤眼流盼", "碧眼盈波", " 里目含威", " 眼睛明亮", " 眼睛无神", " 眼睛发亮", "眼睛贼亮", " 眼睛有神", " 珠黑眼亮", " 冷目灼灼",
            " 乌黑眼睛", "褐色眼睛", " 棕色眼睛", " 蓝色眼睛", " 炯炯发光", " 含情脉脉", "眼射怒火", " 眼眯成线", " 眼睛有神", " 眼如星星", " 眼如秋水", "眼闪秋波",
            " 眼角皱纹", " 眼梢细长", " 眼花缘乱", " 头晕眼花", "垂着眼皮", " 口歪眼斜", " 火眼金睛", " 乌黑眸子", " 两目如锥", "两目如剑", " 侧目而视", " 横目而视",
            " 怒目而视", " 瞠目结舌", "明眸皓齿", " 左顾右盼", " 顾盼生神", " 舒眉展眼", " 星眼微扬", "眉目疏朗", " 双瞳剪水", " 泪眼模糊", " 睡眼惺松", "醉眼朦胧",
            "眼波流盼", " 鹰瞵鹗视", " 眼如点漆", " 珠如黑漆", " 两眼无神", "两眼混浊", " 目光明亮", " 目不斜视", " 神采焕发", " 老眼昏花", "贼眉鼠眼", " 浓眉大眼",
            " 剑眉大眼", " 明眉大眼", " 秀眉大眼", "浓眉俊眼", " 黑眉亮眼", " 明眉锐眼", " 剑眉星眼", " 剑眉虎眼", "浓眉环眼", " 剑眉凤眼", " 剑眉星眼", " 浓眉豹眼",
            " 浓眉怪眼", "细眉俏服", " 柳眉杏眼", " 娥眉观眼", " 纤眉细眼", " 龙眉凤眼", "疏眉细眼", " 淡眉圆眼", " 浓眉圆眼", " 浓眉厉眼", " 娥眉杏眼", "笑眉笑眼",
            " 慈眉笑眼", " 直眉直眼", " 愣眉怔眼", " 直眉瞪眼", "坚眉瞪眼", " 横眉冷眼", " 横眉瞪眼", " 横眉棱眼", " 急眉火眼", "皱眉瞪眼", " 斜眉吊眼", " 灰眉溜眼",
            " 死眉塌眼", " 灰眉土眼", "横眉立眼", " 恶眉瞪眼", " 眩人眼目", " 金刚怒目", " 獐头鼠目", "秀眉俊目", " 慈眉秀目", " 浓眉朗目", " 目光和蔼", " 目光慈样",
            "目光严厉", " 目光逼人", " 目光灼人", " 目光炯炯", " 目横丹凤", "目光闪烁", " 目光四射", " 目光如电", " 目光如剑", " 目光敏锐", "目光深邃", " 目光如豆",
            " 目光呆滞", " 目不转睛", " 目不暇接", "目不交睫", " 目送手挥", " 目瞪口呆", " 目眦尽裂", " 目空一切", "目不暇接", " 豹头环眼", " 大如牛眼", " 眼似铜铃",
            " 立眉竖眼", "细眉小眼", " 突睛火眼", " 恶眉恶眼", " 贼眉贼眼", " 土眉土眼", "球黑眼亮", " 愁眉泪眼", " 淡眉鼠眼", " 秃眉蛇眼", " 邪眉邪眼", "乌眉鼠眼",
            " 蛇眉鼠眼", " 贼眉色眼", " 欢眉浓眼", " 秀眉丽眼", "浓眉凤眼", " 浓眉阔目", " 娥眉凤目", " 龙眉凤目", " 长眉俊目", "剑眉星目", " 蚕眉虎目", " 剑眉虎目",
            " 清眉朗目", " 细眉朗目", "细眉细目", " 细眉俊目", " 秀眉俊目", " 慈眉善目", " 和眉美目", "喜眉笑目", " 聪眉慧目", " 陡眉细目", " 凶眉凶目", " 垂眉敛目",
            "拧眉横目", " 横眉咧目", " 横眉怒目", " 横眉冷日", " 横眉立目", "怒眉立目", " 皱眉立目", " 立眉怒目", " 立眉根目", " 凶眉横目", "横眉乍目", " 立眼竖目",
            " 眉粗眼大", " 眼大眉浓", " 眉清日朗", "眼大眉粗", " 眼深眉浓", " 眉慈目善", " 眉俊目秀", " 虎目浓眉", "秀目黛眉", " 虎目剑眉", " 善目慈眉", " 虎目龙眉",
            " 俊目修眉", "目秀眉清", " 怒目横眉", " 眉疏目朗", " 眉清目秀", " 眉精眼亮", "眉舒目展", " 眉开眼笑", " 眼深眉浓", " 立眼竖眉", " 眉目清秀", "眉目清朗",
            " 眉目如画", " 眉目俊秀", " 眉目灵秀", " 眉眼如画", "眉眼伶俐", " 眉眼动人", " 眉眼俊秀", " 杏眼柳眉", " 明眸秀眉", "一双俊眼", " 一仅杏眼", " 一双凤眼",
            " 一双大眼", " 一双俏眼", "一双凹用", " 一双小眼", " 一双泪眼", " 一双秀目", " 一双鹰目", "一对鹰眼", " 一级狼眼", " 两只小眼", " 目若朗星", " 目如星罡",
            "淡蓝眼睛", " 浅蓝眼睛", " 灰色眼睛", " 死鱼眼眼", " 小黑眼睛", "银铃大眼", " 杏子眼儿", " 小蓝眼睛", " 蛤蟆眼睛", " 大大的眼", "乌黑眸子", " 暴眼蓝睛",
            " 刁眼暴睛", " 杏核眼儿", " 火眼金晴", "乌黑眼珠", " 黑眼珠儿", " 鼓鼓眼儿", " 眼睛很大", " 眼睛浅蓝", "眼睛深蓝", " 眼瞳黑深", " 眼梢细长", " 眼窝深陷",
            " 眼睛深凹", "眼睛略斜", " 眼睛斜视", " 眼睛近视", " 眼睛充血", " 眼发红肿", "眼皮耷拉", " 碧眼突出", " 活泼眼睛", " 枯涩的眼", " 呆斜着眼", "眼仁褐黄",
            "眼神茫然", " 眼神朦胧", " 眼睛细小", " 眼神复杂", "眼神放火", " 眼神闪亮", " 眼神机警", " 眼神暗淡", " 圆圆的眼", "眼神散乱", " 三角眼睛", " 三角怪眼",
            " 三角吊眼", " 黑亮亮的", "水晶晶的", " 水灵灵的", " 水汪汪的", " 圆溜溜的", " 滴溜溜地", "乌溜溜的", " 贼鼠鼠地", " 豁豁亮亮", " 又大又亮", " 乌黑闪亮",
            "黑宝石般", " 黑葡萄似", " 乌黑有神", " 特别有神", " 秋水一般", "盈盈秋水", " 乌黑明亮", " 清澈明亮", " 深沉睿智", " 深不可测", "锐利有神", " 黑白分明",
            " 深蓝色的", " 深蓝碧绿", " 忽闪忽闪", "溜圆溜圆", " 转来转去", " 深邃犀利", " 滴溜溜转", " 失掉光彩", "暗淡无光", " 少光无色", " 布满血丝", " 微微凹陷",
            "雪白牙齿", " ", " 齿如列贝", " 笑不露齿", " 齿冠锐利", " 嘴尖牙利", " 齿如瓠犀", " 狼牙锯齿", "明眸皓齿", " 玉米银齿", " 牙排碎玉", " 齿白唇红",
            " 齿如白瓷", "齿如排玉", " 齿冷舌麻", " 伶牙俐齿", " 犬牙交错", " 乳牙初长", "光洁闪亮", " 牙白似玉", "玉粳白露", " 齿如瓠犀", " 齿若编贝", " 玉米白牙",
            "雪白细牙", " 皓玉齐齿", " 森森白齿", " ", "满头飞絮", " 白发如银", " 金发碧眼", " 云鬟染银", " 发浓鬓重", "两鬓银丝", " 鬓发斑白", " 鬓发染霜",
            " 鬓若银霜", " 两鬓杂雪", "鬓角花白", " 云髻高枕", "玉簪留香", " 辫子粗短", " 白发斑斑", "发不遮项", " 发如乱麻", " 发型新颖", " 鹤发童颜", " 须发如银",
            "红颜银须", " 蓬松自然", " 长辫垂胸", " 秀发柔美", " 乌黑油亮", "云鬓高耸", " 堆云砌墨", " 浓密柔润", " 头发浓黑", " 头发乌润", "乌发如云", " 乌发长披",
            " 乌云蓬松", " 乌发纷披", " 黑黑短发", "乌黑秀发", " 绺绺黑发", " 青丝细发", " 黑发如云", " 满头浓发", "满头青丝", " 三尺青丝", " 青丝黑发", " 棕黑头发",
            " 秀发油黑", "黑发披肩", " 黑发飘拂", " 黑发如漆", " 发辫乌黑", " 乌黑油亮", "乌黑卷曲", " 乌黑光洁", " 乌黑浓密", " 乌黑发亮", " 头发金黄", "头发稍黄",
            " 头发枯黄", " 金发乱灿", " 金发披肩", " 黄色卷发", "淡黄头发", " 金发卷曲", " 满头金发", " 金丝头发", " 灰白头发", "灰色厚发", " 灰色头发", " 长发灰白",
            " 满头灰发", " 灰白夹杂", "黑白夹杂", " 头发斑白", " 头发卷曲", " 鬓发半白", " 鬓发花白", "鬓角斑白", " 鬓角花白", " 两鬓斑白", " 两鬓微露", " 鬓角微露",
            "发鬓花白", " 鬓发苍白", " 两鬓苍苍", " 斑斑白发", " 头发露白", "发已如霜", " 白发如雪", " 白发盈颠", " 白发如霜", " 白鬓银丝", "银丝白发", " 满头银发",
            " 满头飞雪", " 满头银丝", " 雪盖头顶", "一头银发", " 白发如银", " 白发皤然", " 白发苍苍", " 银丝缕缕", "鬓发如霜", " 鬓发染霜", " 鬓发皆白", " 鬓如银霜",
            " 鬓染秋霜", "鬓发飘染", " 两鬓雪白", " 双鬓如霜", " 满鬓白发", " 华发霜鬓", "霜染两鬓", " 丝丝白发", " 银丝鬓发", " 如雪如霜", " 由灰变白", "白发蓬乱",
            " 银发披肩", " 银丝满顶", " 齐耳短发", " 茸茸短发", "短发复额", " 短发及颈", " 短发散乱", " 头发很短", " 蓬松短发", "缕缕短发", " 茸茸短发", " 蓬松短发",
            " 缕缕短发", " 一丝细发", "一圈卷发", " 一绺头发", " 自然卷发", " 金发卷曲", " 发茬粗黑", "满头银发", " 一头秀发", " 银眉鹤发", " 露眉雪发", " 披头散发",
            "平型中发", " 直式中发", " 飞扬中发", " 后梳短发", " 卷曲短发", "覆额短发", " 卷松短发", " 时卷中发", " 俏丽中发", " 内弯中发", "卷花中发", " 披肩中发",
            " 弧型中发", " 波纹长发", " 卷曲长发", "直式长发", " 卷松长发", " 典雅长发", " 旁分长发", " 浪漫长发", "须状长发", " 盘夹长发", " 马尾长发", " 粗密头发",
            " 头发乌黑", "头发蓬乱", " 满头乌丝", " 青丝满头", " 皓发庞眉", " 刘海齐眉", "头发弯曲", " 一头巷发", " 卷曲蓬松", " 一圈卷发", " 曲曲卷卷", "头发散乱",
            " 头发蓬散", " 头发披散", " 头发蓬松", " 毛发蓬乱", "头发蓬蓬", " 散着头发", " 乱发满头", " 秀发蓬松", " 鬓发蓬乱", "乱蓬蓬的", " 蓬蓬松松", " 头发浓密",
            " 浓密蓬松", " 丰盛稠密", "丰盛飘垂", " 又密又厚", " 又长又密", " 头生密发", " 满头浓发", "头发稀疏", " 头发较稀", " 鬓发稀疏", " 稀稀疏疏", " 头发半秃",
            "头发脱落", " 头发脱秃", " 头发光溜", "头发流油", " 头发发亮", "头发太硬", " 头发如鬓", " 满头秀发", " 漂亮头发", " 一头秀发", "一丝细发", " 一绺头发",
            " 鬓发如刺", " 浅色头发", " 刘海飘动", "拖肩小辫", "细长辫子", " 又长又亮", " 又长又白", " 又粗又长", "留着背头", " 背头乌亮", " 蓄着分头", " 剪着平头",
            " 自然卷发", "蟠桃发髻", " 梳个发髻", " 发梳高髻", " 自由发式", " 波浪发式", "漩涡发式", " 两边披分", " 滑腻柔软", " 油亮光洁", " 毛茸茸的", "笔立直竖",
            " 又粗又硬", "血盆大口", " 樱桃小口", " 铁嘴钢牙", " 多嘴多舌", " 巧烟滑舌", "嘟嘴鼓腮", " 油嘴滑舌", " 红嘴白牙", " 张口结舌", " 口若悬河", "口中樱桃",
            " 口干舌燥", " 嘴唇干裂", " 嘴角下撇", " 嘴小唇薄", "棱角分明", " 鲜红小嘴", " 小薄片嘴", " 一张大嘴", " 鲇鱼阔嘴", "黄牙利嘴", " 微瘪的嘴", " 干瘪的嘴",
            " 阔阔的嘴", " 四字海口", "四方阔口", " 菱用海口", " 菱角小嘴", " 樱桃小口", " 狮子阔口", "大嘴岔子", " 薄嘴皮儿", " 嘴如樱桃", " 嘴若含丹", " 嘴巴宽大",
            "嘴大唇厚", " 嘴巴稍宽", " 嘴巴如猴", " 嘴巴小巧", " 嘴巴徽翘", "嘴巴橛着", " 嘴角微翘", " 口若含丹", " 檀口含丹", " 檀口轻盈", "嘴是兔唇", " 口像血盆",
            " 元宝嘴巴", " 唇如胭脂", " 唇若丹霞", "唇似涂朱", " 唇似绽桃", " 唇似樱红", " 唇若涂脂", " 唇红如血", "嘴唇红润", " 玫瑰含雪", " 下巴很尖", " 下巴前突",
            " 尖下巴颏", "樱桃小嘴", " 嘴唇发紫", " 嘴唇苍白", " 嘴角上扬", " 嘴挂油瓶", "嘴尖唇薄", " 笨嘴拙舌", " 尖嘴猴腮", " 瘪嘴老头", " 撅起嘴巴", "朱唇皓齿",
            " 唇小嘴尖", " 唇如胭脂", " 唇如朱砂", " 唇似樱桃", "唇枪舌剑", " 唇焦舌燥", " 红唇白牙", " 巧舌如黄", " 舌敝唇焦", "嘴唇烟黑", " 娇唇红润", " 娇唇朱红",
            " 嘴唇微红", " 唇无血色", "枯唇烟黑", " 嘴唇肥厚", " 嘴唇较厚", " 瘪嘴薄唇", " 嘴唇丰满", "唇方口正", " 温柔嘴唇", " 瘪瘦无门", " 两唇青紫", " 舌敝唇焦",
            "纪后做启", " 先后很快", " 付后很肯", " 来后昭告", " 回唇白环", "柔唇微启", " 尖嘴暴牙", " 玉齿珠唇", " 唇红齿白", " 唇红肤白", "玫瑰榴齿", " "
        };
		
		/// <summary>
		/// after all sync we do this.
		/// </summary>
		/// <param name="self"></param>
		public static async ETTask PopulateInit(this UnitComponent self)
		{
			var namesCount = names.Length;
			var playerCount = self.PlayerUnits.Count;
			var populateNum = ConstValue.PopulateGoalNum - playerCount;
			float populateChance = populateNum / 900f;

			for (int i = 0; i < 30; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					if (RandomHelper.RandFloat01() > populateChance)
					{
						continue;
					}
					var nameRandIndex = RandomHelper.RandomNumber(0,namesCount);
					
					var id = IdGenerater.Instance.GenerateUnitId(self.DomainZone());
					Unit unit = self.AddChildWithId<Unit, int>(id, 0);
					unit.AddComponent<MoveComponent>();
					// unit.AddComponent<ObjectWait>();
					unit.AddComponent<CharComp>().playerData = new player()
					{
						x = i/30f,
						y = j/30f,
						player_name = names[nameRandIndex],
						figure_id = RandomHelper.RandInt32()%11,
					};
					// unit.Position = new Vector3(i / 30f, 0f, j / 30f);
					self.AddNpc(unit);
					Game.EventSystem.Publish(new EventType.AfterUnitCreate(){Unit = unit});
				}
				await TimerComponent.Instance.WaitFrameAsync();
			}

			Log.Info("all units generated!");
		}
		
		public static async ETTask CreatePlayer(this UnitComponent self, player messageOnePlayer)
		{
			if (self.PlayerUnits.ContainsKey(messageOnePlayer.player_id))
			{
				Log.Info("Player already existing in scene, skip creating player...");
				return;
			}
			
			var id = IdGenerater.Instance.GenerateUnitId(self.DomainZone());
			Unit unit = self.AddChildWithId<Unit, int>(id, 0);//todo configId
			unit.Position = new Vector3(messageOnePlayer.x, 0f, messageOnePlayer.y);
			// unit.Forward = RandomHelper.RandFloat01() < 0.5f? 1f : -1f;
			unit.AddComponent<MoveComponent>();
			unit.AddComponent<ObjectWait>();
			var charComp = unit.AddComponent<CharComp,player>(messageOnePlayer);
			self.AddPlayer(unit);
			await Game.EventSystem.PublishAsync(new EventType.AfterUnitCreate(){Unit = unit});
			if (charComp.playerData.is_dj > 0)
			{
				Game.EventSystem.PublishAsync(new EventType.BecomeDJ() { Unit = unit }).Coroutine();
			}
			// todo remove some npc units by chance..
		}

		public static Unit MyPlayerUnit(this UnitComponent self)
		{
			#if NOT_UNITY
			var myPlayerId = LoginHelper.UserId75;
			#else
			var myPlayerId = UnityEngine.PlayerPrefs.GetInt(LoginHelper.USER_ID);
			#endif
			return self.PlayerUnits[myPlayerId];
		}
	}
}