using OpenFL.OpenCLInterop.Serializers;
using OpenFL.Serialization.Serializers.Internal;
using OpenFL.Serialization.Serializers.Internal.BufferSerializer;

using PluginSystem.Core.Pointer;
using PluginSystem.Utility;

namespace OpenFL.OpenCLInterop
{
    public class CLSerializers : APlugin<SerializableFLProgramSerializer>
    {

        

        public override string Name => "open-fl-cl-serializers";

        public override void OnLoad(PluginAssemblyPointer ptr)
        {
            base.OnLoad(ptr);
            RandomFLBufferSerializer rbuf = new RandomFLBufferSerializer();
            UnifiedRandomFLBufferSerializer urbuf = new UnifiedRandomFLBufferSerializer();
            PluginHost.BufferSerializer.AddSerializer(typeof(RandomFLBufferSerializer), rbuf);
            PluginHost.BufferSerializer.AddSerializer(typeof(UnifiedRandomFLBufferSerializer), urbuf);
        }

    }
}