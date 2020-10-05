using OpenFL.Core.Buffers;
using OpenFL.Core.DataObjects.SerializableDataObjects;
using OpenFL.Core.ElementModifiers;
using OpenFL.DefaultInstructions.Instructions;

namespace OpenFL.OpenCLInterop.BufferCreators.Random
{
    public class SerializableUnifiedRandomFLBuffer : SerializableFLBuffer
    {

        public readonly int Size;

        public SerializableUnifiedRandomFLBuffer(string name, FLBufferModifiers modifiers, int size) : base(
             name,
             modifiers
            )
        {
            Size = size;
        }

        public override FLBuffer GetBuffer()
        {
            return URandomFLInstruction.ComputeUrnd(IsArray, Size, Modifiers.InitializeOnStart);
        }

        public override string ToString()
        {
            return base.ToString() + $"urnd {Size}";
        }

    }
}