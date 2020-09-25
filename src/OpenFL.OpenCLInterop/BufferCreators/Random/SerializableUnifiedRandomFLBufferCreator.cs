using System;

using OpenFL.Core.Buffers.BufferCreators;
using OpenFL.Core.DataObjects.SerializableDataObjects;
using OpenFL.Core.ElementModifiers;

namespace OpenFL.OpenCLInterop.BufferCreators.Random
{
    public class SerializableUnifiedRandomFLBufferCreator : ASerializableBufferCreator
    {

        public override SerializableFLBuffer CreateBuffer(
            string name, string[] args, FLBufferModifiers modifiers,
            int arraySize)
        {
            if (modifiers.IsArray && arraySize <= 0)
            {
                throw new InvalidOperationException(
                                                    $"URandom Array buffer \"{name}\" has to be initialized with a size as the first argument"
                                                   );
            }

            return new SerializableUnifiedRandomFLBuffer(name, modifiers, arraySize);
        }

        public override bool IsCorrectBuffer(string bufferKey)
        {
            return bufferKey == "urnd";
        }

    }
}