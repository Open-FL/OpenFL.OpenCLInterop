using PluginSystem.Core.Interfaces;
using PluginSystem.Utility;

namespace OpenFL.OpenCLInterop
{
    public class CLInteropPlugin : APlugin<IPluginHost>
    {
    	
        public override bool SatisfiesHostType(IPluginHost potentialHost)
        {
            return false;
        }

    }
}