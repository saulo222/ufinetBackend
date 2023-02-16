using INGETEC_INFRA_TOOLS_CORE;

namespace INGETEC_INFRA_TOOLS_AGG
{
    public interface ITools
    {
        string EncryptKey(string cadena);
        string DecryptKey(string clave);

    }
}
