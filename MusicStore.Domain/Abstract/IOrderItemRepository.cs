using System.Collections.Generic;
using MusicStore.Domain.Entities;
using System.Data.Entity;
using MusicStore.Domain.Models;

namespace MusicStore.Domain.Abstract
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> OrderItem { get; }
        void AddOrder(int OrderID, CartViewModel model);


    }
}