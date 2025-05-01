using CQRSLib.CQRS.Commands;
using CQRSLib.Data;
using CQRSLib.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLib.CQRS.Handlers
{
    public class InsertHandler : IRequestHandler<InsertItemCommand, Item>
    {
        public AppdbContext _db;

        public InsertHandler(AppdbContext db)
        {
            _db= db;
        }
        public async Task<Item> Handle(InsertItemCommand request, CancellationToken cancellationToken)
        {
             await _db.Items.AddAsync(request.item);
            _db.SaveChanges();
            return await Task.FromResult(request.item);
        }
    }
}
