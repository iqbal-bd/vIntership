using IMS.UseCases;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.EfCore
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}