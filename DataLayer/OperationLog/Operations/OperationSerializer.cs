using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DataLayer.OperationLog.Operations
{
    public class OperationSerializer : IOperationSerializer
    {
        private long position;
        private readonly Queue<long> lenghts;

        public OperationSerializer()
        {
            lenghts = new Queue<long>();
        }

        public byte[] Serialize(IOperation operation)
        {
            var serialized = JsonConvert.SerializeObject(operation);
            var bytes = Encoding.UTF8.GetBytes(serialized);
            lenghts.Enqueue(bytes.Length);
            return bytes;
        }

        public IOperation Deserialize(Stream opLogStream)
        {
            opLogStream.Seek(position, SeekOrigin.Current);
            if (lenghts.Count == 0)
                return null;
            var lenght = lenghts.Dequeue();
            var data = new byte[lenght];
            opLogStream.Read(data, 0, data.Length);
            position += lenght;
            var serialized = Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<Operation>(serialized);
        }
    }
}