using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JDPesca.Models;

namespace JDPesca.Services
{
    public interface IShoppingBasketService
    {
        Task AddItem(ShoppingBasket newItem);

}
}