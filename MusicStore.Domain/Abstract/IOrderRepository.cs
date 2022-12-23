using System.Collections.Generic;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;

using System.Data.Entity;

namespace MusicStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Order { get; }

       void CreateNewOrder(int ShipID, int UID, CartViewModel model);
    }
}
