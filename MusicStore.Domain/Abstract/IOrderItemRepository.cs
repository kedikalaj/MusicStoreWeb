using System.Collections.Generic;
using MusicStore.Domain.Entities;
using System.Data.Entity;

namespace MusicStore.Domain.Abstract
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> OrderItem { get; }


    }
}