using ECommerceSite.Models;

namespace ECommerceSite.Services
{
	public interface ICustomerService
	{
        public ShopCustomer GetCustomer(int id);
    }
}
