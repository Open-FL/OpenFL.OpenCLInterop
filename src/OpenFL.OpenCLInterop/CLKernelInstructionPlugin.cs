using OpenCL.Wrapper;

using OpenFL.Core.Instructions.InstructionCreators;
using OpenFL.OpenCLInterop.InstructionCreators;

using PluginSystem.Core.Pointer;
using PluginSystem.Utility;

namespace OpenFL.OpenCLInterop
{
    public class CLKernelInstructionPlugin: APlugin<FLInstructionSet>
    {
        
        public override void OnLoad(PluginAssemblyPointer ptr)
        {
            base.OnLoad(ptr);

            PluginHost.AddInstruction(new KernelFLInstructionCreator(PluginHost.Database));

            if (PluginHost.Database.TryGetClKernel("_arrange", out CLKernel arrangeKernel))
            {
                PluginHost.AddInstruction(new GPUArrangeInstructionCreator(arrangeKernel));
            }
        }

    }
}
