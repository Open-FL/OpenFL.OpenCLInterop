using OpenFL.Core.ElementModifiers;
using OpenFL.OpenCLInterop.BufferCreators.Random;
using OpenFL.Serialization.Serializers.Internal;

using Utility.Serialization;

namespace OpenFL.OpenCLInterop.Serializers
{
    public class RandomFLBufferSerializer : FLBaseSerializer
    {

        public override object Deserialize(PrimitiveValueWrapper s)
        {
            string name = ResolveId(s.ReadInt());
            FLBufferModifiers bmod = new FLBufferModifiers(name, s.ReadArray<string>());
            return new SerializableRandomFLBuffer(name, bmod, bmod.IsArray ? s.ReadInt() : 0);
        }

        public override void Serialize(PrimitiveValueWrapper s, object obj)
        {
            SerializableRandomFLBuffer input = (SerializableRandomFLBuffer) obj;
            s.Write(ResolveName(input.Name));
            s.WriteArray(input.Modifiers.GetModifiers().ToArray());
            if (input.IsArray)
            {
                s.Write(input.Size);
            }
        }

    }
}