using CQRSLib.Model;
using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLib.CQRS.Commands
{
    public record InsertItemCommand(Item item):IRequest<Item>;
    
}
