using DataLayer.DataModel;

namespace DataLayer.OperationLog.Operations
{
    public interface IOperation
    {
        Item Item { get; set; }
    }
}