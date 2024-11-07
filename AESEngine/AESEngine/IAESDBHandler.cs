using AESModel;

namespace AESEngine
{
    public interface IAESDBHandler
    {
        string GetAESData();

        bool GenerateScript(ScriptModel scriptModel);
    }
}
