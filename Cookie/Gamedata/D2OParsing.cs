using Cookie.Datacenter;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.D2p;
using Cookie.Gamedata.I18n;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Cookie.Gamedata
{
    public class D2OParsing
    {
        public static string GetChallengeName(int Id)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<Challenge>(Id).NameId);
            return I18nDataManager.Instance.ReadText(Convert.ToInt32(objectValue));
        }

        public static string GetServerName(ushort id)
        {
            var objectValue = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<Server>(id).NameId);
            return I18nDataManager.Instance.ReadText(Convert.ToInt32(objectValue));
        }

        public static string GetJobName(int jobId)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<Job>(jobId).NameId);
            return I18nDataManager.Instance.ReadText(Convert.ToInt32(objectValue));
        }

        public static string GetSpellName(int spellId)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<Spell>(spellId).NameId);
            return I18nDataManager.Instance.ReadText(Convert.ToInt32(objectValue));
        }

        public static object GetNameCity(int idArea)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<SubArea>(idArea).NameId);
            return I18nDataManager.Instance.ReadText(Convert.ToInt32(objectValue));
        }

        public static string GUIDToName(uint guid)
        {
            object id = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<Item>(guid).NameId);
            return I18nDataManager.Instance.ReadText(Convert.ToInt32(id));
        }

        public static Image GFXItem(uint GID)
        {
            object id = RuntimeHelpers.GetObjectValue(ObjectDataManager.Instance.Get<Item>(GID).IconId);
            return ImageManager.GetImage(Convert.ToInt32(id));
        }
    }
}
