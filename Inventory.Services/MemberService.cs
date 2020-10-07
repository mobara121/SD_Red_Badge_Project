using Inventory.Data;
using Inventory.Models;
using Inventory_home.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services
{
    public class MemberService
    {
        private readonly Guid _userId;

        public MemberService(Guid userId)
        {
            _userId = userId;
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

            using (var ctx = new ApplicationDbContext())
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

        public MemberDetail GetMemberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                        new MemberDetail
                        {
                            MemberId = entity.Id,
                            MemberName = entity.MemberName,
                            RegisteredDate = entity.RegisteredDate,
                        };
            }
        }

        public bool UpdateMember(MemberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.Id == model.MemberId && e.OwnerId == _userId);

                entity.MemberName = model.MemberName;
                entity.RegisteredDate = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMember(int memberId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.Id == memberId && e.OwnerId == _userId);

                ctx.Members.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
