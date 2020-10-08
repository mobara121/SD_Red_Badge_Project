using Inventory.Data;
using Inventory.Models;
using Inventory_home.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Services
{
    public class ItemService
    {
        //private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        //private ItemCreate model;


        public ItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    OwnerId = _userId,
                    Category = model.Category,
                    ItemName = model.ItemName,
                    Location = model.Location,
                    Shelf = model.Shelf,
                    Qty = model.Qty,
                    StockedDate = DateTimeOffset.Now

                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public object GetMembers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .Items
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new InventoryListItem
                            {
                                Category = e.Category,
                                ItemId = e.Id,
                                ItemName = e.ItemName,
                                Location = e.Location,
                                Shelf = e.Shelf,
                                Qty = e.Qty,
                                StockedDate = e.StockedDate,
                                ModifiedDate = e.ModifiedDate,
                            }
                         );
                return query.ToArray();
            }
        }

        public ItemDetail GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                        new ItemDetail
                        {
                            Category = entity.Category,
                            ItemId = entity.Id,
                            ItemName = entity.ItemName,
                            Location = entity.Location,
                            Shelf = entity.Shelf,
                            Qty = entity.Qty,
                            StockedDate = entity.StockedDate,
                            ModifiedDate = entity.ModifiedDate
                        };
            }
        }

        public bool UpdateItem(ItemEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.Id == model.ItemId && e.OwnerId == _userId);

                entity.Category = model.Category;
                entity.ItemName = model.ItemName;
                entity.Location = model.Location;
                entity.Shelf = model.Shelf;
                entity.Qty = model.Qty;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;            
            }
        }

        public bool DeleteItem(int itemId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.Id == itemId && e.OwnerId == _userId);

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
