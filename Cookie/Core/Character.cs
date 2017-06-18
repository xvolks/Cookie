using Cookie.Gamedata.D2p;
using Cookie.Protocol.Network.Types.Game.Character.Characteristic;
using Cookie.Protocol.Network.Types.Game.Character.Restriction;
using Cookie.Protocol.Network.Types.Game.Data.Items;
using Cookie.Protocol.Network.Types.Game.Look;
using Cookie.Utils.Enums;
using System.Collections.Generic;
using Cookie.Game.Map;

namespace Cookie
{
    public class Character
    {
        public Character()
        {
            Stats = new CharacterCharacteristicsInformations();
            Look = new EntityLook();
            Restrictions = new ActorRestrictionsInformations();
            Inventory = new List<ObjectItem>();
            Spells = new List<SpellItem>();
            Status = CharacterStatus.Disconnected;
            MapData = new MapData();
        }

        public CharacterStatus Status { get; set; }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool Sex { get; set; }
        public CharacterCharacteristicsInformations Stats { get; set; }
        public EntityLook Look { get; set; }
        public sbyte Breed { get; set; }
        public MapData MapData { get; set; }

        public int LifePercentage => (int)(((double)Stats.LifePoints / (double)Stats.MaxLifePoints) * 100);
        public int WeightPercentage => (int)(((double)Weight / (double)MaxWeight) * 100);
        public int EnergyPercentage => (int)(((double)Stats.EnergyPoints / (double)Stats.MaxEnergyPoints) * 100);
        public int XPPercentage => (int)(((double)Stats.Experience / (double)Stats.ExperienceNextLevelFloor) * 100);

        public int CellId { get; set; }
        public int MapId { get; set; }

        public uint Weight { get; set; }
        public uint MaxWeight { get; set; }

        public ActorRestrictionsInformations Restrictions { get; set; }

        public List<ObjectItem> Inventory { get; set; }
        public List<SpellItem> Spells { get; set; }

        public string GetSkinUrl(string mode, int orientation, int width, int height, int zoom)
        {
            EntityLook look = Look;
            string text = "http://staticns.ankama.com/dofus/renderer/look/7";
            text += "b3";
            int num = 0;
            char[] array = look.BonesId.ToString().ToCharArray();
            char[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                char c = array2[i];
                int num2 = num;
                num = num2 + 1;
                text += c.ToString();
                bool flag = num >= array.Length;
                if (flag)
                {
                    text += "7";
                }
                else
                {
                    text += "3";
                }
            }
            int num3 = 0;
            int num4 = 0;
            foreach (ushort current in look.Skins)
            {
                int num2 = num3;
                num3 = num2 + 1;
                text += "c3";
                char[] array3 = current.ToString().ToCharArray();
                char[] array4 = array3;
                for (int j = 0; j < array4.Length; j++)
                {
                    char c2 = array4[j];
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c2.ToString();
                    bool flag2 = num4 >= array3.Length && num3 < look.Skins.Count;
                    if (flag2)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        bool flag3 = num4 < array3.Length && num3 <= look.Skins.Count;
                        if (flag3)
                        {
                            text += "3";
                        }
                    }
                }
                bool flag4 = num3 >= look.Skins.Count;
                if (flag4)
                {
                    text += "7";
                }
            }
            int num5 = 0;
            foreach (int current2 in look.IndexedColors)
            {
                int num2 = num5;
                num5 = num2 + 1;
                text = string.Concat(new object[]
                {
                        text,
                        "c3",
                        num5,
                        "3d3"
                });
                num4 = 0;
                char[] array5 = current2.ToString().ToCharArray();
                char[] array6 = array5;
                for (int k = 0; k < array6.Length; k++)
                {
                    char c3 = array6[k];
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c3.ToString();
                    bool flag5 = num4 >= array5.Length && num5 < look.IndexedColors.Count;
                    if (flag5)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        bool flag6 = num4 < array5.Length && num5 <= look.IndexedColors.Count;
                        if (flag6)
                        {
                            text += "3";
                        }
                    }
                }
                bool flag7 = num5 >= look.IndexedColors.Count;
                if (flag7)
                {
                    text += "7";
                }
            }
            int num6 = 0;
            foreach (short current3 in look.Scales)
            {
                int num2 = num6;
                num6 = num2 + 1;
                text += "c3";
                num4 = 0;
                char[] array7 = current3.ToString().ToCharArray();
                char[] array8 = array7;
                for (int l = 0; l < array8.Length; l++)
                {
                    char c4 = array8[l];
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c4.ToString();
                    bool flag8 = num4 >= array7.Length && num6 < look.Scales.Count;
                    if (flag8)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        bool flag9 = num4 < array7.Length && num6 <= look.Scales.Count;
                        if (flag9)
                        {
                            text += "3";
                        }
                    }
                }
                bool flag10 = num6 >= look.Scales.Count;
                if (flag10)
                {
                    text += "7";
                }
            }
            text = string.Concat(new object[]
            {
                    text,
                    "d/",
                    mode,
                    "/",
                    orientation,
                    "/",
                    width,
                    "_",
                    height,
                    "-",
                    zoom,
                    ".png"
            });
            return text;
        }
    }
}
