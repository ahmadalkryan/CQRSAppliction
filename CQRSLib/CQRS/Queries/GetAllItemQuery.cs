using CQRSLib.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLib.CQRS.Commands
{
    public record GetAllItemQuery:IRequest<List<Item>>;
        
    
}
