using Cookie.API.Protocol;
using Cookie.API.Utils.IO;

namespace Cookie.API.Network
{
    public interface IMessageBuilder
    {
        NetworkMessage BuildMessage(ushort messageid, IDataReader reader);
    }
}