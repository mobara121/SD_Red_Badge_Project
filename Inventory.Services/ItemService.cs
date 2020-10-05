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
                    
                    ItemName = model.ItemName,
                    Location = model.Location,
                    Qty = model.Qty,
                    StockedDate = DateTimeOffset.Now

                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
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
                                ItemId = e.Id,
                                ItemName = e.ItemName,
                                Location = e.Location,
                                Qty = e.Qty,
                                StockedDate = e.StockedDate
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
                            ItemId = entity.Id,
                            ItemName = entity.ItemName,
                            Location = entity.Location,
                            Qty = entity.Qty,
                            StockedDate = entity.StockedDate,

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

                entity.ItemName = model.ItemName;
                entity.Location = model.Location;
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

        public bool CreateMember(MemberCreate model)
        {
            var entity =
                new Member()
                {
                    OwnerId = _userId,
                    MemberName = model.MemberName,
                    RegisteredDate = DateTimeOffset.Now
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MemberList> GetMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Members
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MemberList
                                {
                                    MemberId = e.Id,
                                    MemberName = e.MemberName,
                                    RegisteredDate = e.RegisteredDate
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
