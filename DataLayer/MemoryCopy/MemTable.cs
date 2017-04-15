using System.Collections.Generic;
using DataLayer.DataModel;
using DataLayer.OperationLog;
using DataLayer.OperationLog.Operations;

namespace DataLayer.MemoryCopy
{
    public class MemTable : IMemTable
    {
        private readonly IOpLogWriter opLogWriter;
        private readonly Dictionary<string, Item> values;

        public MemTable(IOpLogWriter opLogWriter)
        {
            this.opLogWriter = opLogWriter;
            values = new Dictionary<string, Item>();
        }

        public void Add(Item item)
        {
            values[item.Key] = item;
            opLogWriter.Write(new Operation(item));
        }

        public void Apply(Item item)
        {
            values[item.Key] = item;
        }

        public Item Get(string key)
        {
            return values[key];
        }
    }
}