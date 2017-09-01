using Cookie.ProtocolBuilder.Protocol.Enums;

namespace Cookie.ProtocolBuilder.Protocol
{
    public class ProtocolClassVariable
    {
        public string Name { get; set; }
        public VarType TypeOfVar { get; set; }
        public ReadMethodType MethodType { get; set; }
        public int Index { get; set; }
        public string ObjectType { get; set; }
        public string VectorFieldRead { get; set; }
        public string VectorFieldWrite { get; set; }
        public string ReadMethod { get; set; }
        public string WriteMethod { get; set; }
    }
}