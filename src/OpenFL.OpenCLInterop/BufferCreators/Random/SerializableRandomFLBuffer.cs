using OpenFL.Core.Buffers;
using OpenFL.Core.DataObjects.SerializableDataObjects;
using OpenFL.Core.ElementModifiers;
using OpenFL.DefaultInstructions.Instructions;

namespace OpenFL.OpenCLInterop.BufferCreators.Random
{
    public class SerializableRandomFLBuffer : SerializableFLBuffer
    {

        public readonly int Size;

        public SerializableRandomFLBuffer(string name, FLBufferModifiers modifiers, int size) : base(name, modifiers)
        {
            Size = size;
        }

        public override FLBuffer GetBuffer()
        {
            return RandomFLInstruction.ComputeRnd(IsArray, Size, Modifiers.InitializeOnStart);
        }

        public override string ToString()
        {
            return base.ToString() + $"rnd {Size}";
        }

    }
}