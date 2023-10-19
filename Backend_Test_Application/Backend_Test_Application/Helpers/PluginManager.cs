using Backend_Test_Application.Entities;
using Backend_Test_Application.Interfaces;
using Backend_Test_Application.Plugins;

namespace Backend_Test_Application.Helpers
{
    public class PluginManager
    {
        private List<IImagePlugin> plugins = new List<IImagePlugin>() { new PluginSample() };
        MemoryStream resultSrteam = new();
        public void AddPlugin(IImagePlugin plugin)
        {
            plugins.Add(plugin);
        }

        public void RemovePlugin(IImagePlugin plugin)
        {
            plugins.Remove(plugin);
        }

        public MemoryStream ApplyEffects(ExtendedImage extendedImage)
        {

            foreach (var plugin in plugins)
                resultSrteam = plugin.ApplyEffect(extendedImage);


            return resultSrteam;
        }
    }
}

