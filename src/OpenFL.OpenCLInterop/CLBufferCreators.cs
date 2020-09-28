using System;
using System.Reflection;

using OpenFL.Core.Buffers.BufferCreators;

using PluginSystem.Core.Pointer;
using PluginSystem.Utility;

namespace OpenFL.OpenCLInterop
{
    public class CLBufferCreators : APlugin<BufferCreator>
    {

        public override void OnLoad(PluginAssemblyPointer ptr)
        {
            base.OnLoad(ptr);

            Type[] ts = Assembly.GetExecutingAssembly().GetExportedTypes();

            Type target = typeof(ASerializableBufferCreator);

            for (int i = 0; i < ts.Length; i++)
            {
                if (target != ts[i] && target.IsAssignableFrom(ts[i]))
                {
                    ASerializableBufferCreator bc = (ASerializableBufferCreator)Activator.CreateInstance(ts[i]);
                    PluginHost.AddBufferCreator(bc);
                }
            }
        }

    }
}