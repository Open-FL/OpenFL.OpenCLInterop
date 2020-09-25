using OpenFL.Core.Buffers.BufferCreators.BuiltIn.FromFile;
using OpenFL.Core.DataObjects.SerializableDataObjects;
using OpenFL.Core.Exceptions;
using OpenFL.Core.ProgramChecks;

using Utility.IO.Callbacks;

namespace OpenFL.OpenCLInterop.Validators.Checking
{
    public class FilePathValidator : FLProgramCheck<SerializableFLProgram>
    {

        public override int Priority => 5;

        public override FLProgramCheckType CheckType => FLProgramCheckType.InputValidation;

        public override object Process(object o)
        {
            SerializableFLProgram input = (SerializableFLProgram) o;
            for (int i = 0; i < input.DefinedBuffers.Count; i++)
            {
                if (input.DefinedBuffers[i] is SerializableFromFileFLBuffer buf)
                {
                    if (!IOManager.FileExists(buf.File))
                    {
                        throw new FLProgramCheckException(
                                                          $"File: {buf.File} referenced in Defined Buffer: {buf.Name} but the file does not exist.",
                                                          this
                                                         );
                    }
                }
            }

            return input;
        }

    }
}