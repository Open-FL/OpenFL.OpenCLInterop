using OpenFL.Core.ElementModifiers;
using OpenFL.OpenCLInterop.BufferCreators.Random;
using OpenFL.Serialization.Serializers.Internal;

using Utility.Serialization;

namespace OpenFL.OpenCLInterop.Serializers
{
    public class UnifiedRandomFLBufferSerializer : FLBaseSerializer
    {

        public override object Deserialize(PrimitiveValueWrapper s)
        {
            string name = ResolveId(s.ReadInt());
            string[] mods = s.ReadArray<string>();
            FLBufferModifiers bmod = new FLBufferModifiers(name, mods);

            return new SerializableUnifiedRandomFLBuffer(name, bmod, bmod.IsArray ? s.ReadInt() : 0);
        }

        public override void Serialize(PrimitiveValueWrapper s, object obj)
        {
            SerializableUnifiedRandomFLBuffer input = (SerializableUnifiedRandomFLBuffer) obj;
            s.Write(ResolveName(input.Name));
            s.WriteArray(input.Modifiers.GetModifiers().ToArray());
            if (input.IsArray)
            {
                s.Write(input.Size);
            }
        }

    }
}