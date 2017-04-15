using System.IO;
using DataLayer.OperationLog.Operations;
using DataLayer.Utilities;

namespace DataLayer.OperationLog
{
    public class OpLogManager : IOpLogReader, IOpLogWriter
    {
        private readonly IFile olFile;
        private readonly IOperationSerializer serializer;

        public OpLogManager(IFile olFile, IOperationSerializer serializer)
        {
            this.olFile = olFile;
            this.serializer = serializer;
        }

        public bool Read(out IOperation operation)
        {
            using (var file = olFile.GetStream())
            {
                operation = serializer.Deserialize(file);
            }
            return operation != null;
        }

        public void Write(IOperation operation)
        {
            var data = serializer.Serialize(operation);
            using (var file = olFile.GetStream())
            {
                file.Seek(file.Length, SeekOrigin.Current);
                file.Write(data, 0, data.Length);
            }
        }
    }
}