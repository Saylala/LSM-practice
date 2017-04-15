using DataLayer.MemoryCopy;
using DataLayer.OperationLog;
using DataLayer.OperationLog.Operations;

namespace DataLayer.Warmup
{
    public class OpLogApplier : IOpLogApplier
    {
        private readonly IOpLogReader opLogReader;

        public OpLogApplier(IOpLogReader opLogReader)
        {
            this.opLogReader = opLogReader;
        }

        public void Apply(IMemTable memTable)
        {
            IOperation operation;
            while (opLogReader.Read(out operation))
            {
                memTable.Apply(operation.Item);
            }
        }
    }
}