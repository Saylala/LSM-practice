using DataLayer.DataModel;

namespace DataLayer.MemoryCopy
{
    public interface IMemTable
    {
        void Add(Item item);
        void Apply(Item item);

        Item Get(string key);
    }
}