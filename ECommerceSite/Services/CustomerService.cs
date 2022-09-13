using ECommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ECommerceDBContext _dBContext;

		public CustomerService(ECommerceDBContext dBContext)
		{
			_dBContext = dBContext;

        }

		public ShopCustomer GetCustomer(int id)
		{
			return _dBContext.ShopCustomers.Include(x => x.Carts).ThenInclude(e => e.Items).FirstOrDefault(c => c.Id == id);
		}
	}
}
