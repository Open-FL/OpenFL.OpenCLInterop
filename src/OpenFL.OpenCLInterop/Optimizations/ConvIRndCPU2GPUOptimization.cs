using System;
using System.Collections.Generic;

using OpenFL.Core.Arguments;
using OpenFL.Core.DataObjects.SerializableDataObjects;
using OpenFL.Core.ProgramChecks;

using Utility.ADL;

namespace OpenFL.OpenCLInterop.Optimizations
{
    public class ConvIRndCPU2GPUOptimization : FLProgramCheck<SerializableFLProgram>
    {
        private static Random seedGenerator = new Random(DateTime.Now.Millisecond);

        public override int Priority => 0;

        public override FLProgramCheckType CheckType => FLProgramCheckType.AggressiveOptimization;

        public override object Process(object o)
        {
            SerializableFLProgram input = (SerializableFLProgram) o;

            foreach (SerializableFLFunction serializableFlFunction in input.Functions)
            {
                for (int i = 0; i < serializableFlFunction.Instructions.Count; i++)
                {
                    SerializableFLInstruction serializableFlInstruction = serializableFlFunction.Instructions[i];
                    if (serializableFlInstruction.InstructionKey == "urnd" ||
                        serializableFlInstruction.InstructionKey == "rnd")
                    {
                        if (serializableFlInstruction.Arguments.Count == 0)
                        {
                            serializableFlFunction.Instructions[i] = new SerializableFLInstruction(
                                 serializableFlInstruction
                                     .InstructionKey +
                                 "_gpu",
                                 new List<
                                     SerializableFLInstructionArgument
                                 >
                                 {
                                     new SerializeDecimalArgument(seedGenerator.Next()),
                                     new SerializeDecimalArgument(seedGenerator.Next())
                                 }
                                );
                            Logger.Log(LogType.Log, "Weaved: " + serializableFlFunction.Instructions[i], 2);
                        }
                        else
                        {
                            Logger.Log(LogType.Log, "Can not Weave random instruction with arguments.", 1);
                        }
                    }
                }
            }

            return input;
        }

    }
}