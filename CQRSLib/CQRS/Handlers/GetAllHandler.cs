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
    public class GetAllHandler : IRequestHandler<GetAllItemQuery, List<Item>>
    {
        AppdbContext _db;

        public GetAllHandler(AppdbContext db)
        {
            _db = db;
        }

        public async Task<List<Item>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
        {
           return   await Task.FromResult(_db.Items.ToList());
                
         }
    }
}
