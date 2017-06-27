using Cookie.API.Protocol;
using Cookie.API.Utils.IO;

namespace Cookie.API.Network
{
    public interface IMessageBuilder
    {
        NetworkMessage BuildMessage(uint messageid, IDataReader reader);
    }
}
