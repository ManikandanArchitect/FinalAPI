using AESModel;

namespace AESEngine
{
    public interface IAESService
    {
        string AESDataCollector();
        bool GenerateScript(ScriptModel scriptModel);
    }
}
