using CQRSLib.CQRS.Commands;
using CQRSLib.Model;
using CQRSLib.Repo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController(IItemRepo repo ,IMediator Im)
        {
            _repo = repo;
            mediatr = Im;
        }

        private readonly IItemRepo _repo;
        private readonly IMediator mediatr;

        [HttpGet]
        public async Task<IActionResult> GetAllItem()
        {
            //var Its =  _repo.GetItems();

            //return Ok(Its);

            var result =await mediatr.Send( new GetAllItemQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByID(int id)
        {
            return Ok(_repo.Item(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item It)
        {
            //_repo.InsertItem(It);
            //return Ok(It);
            var result =await mediatr.Send( new InsertItemCommand(It) );
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public  async Task<IActionResult> DeleteItem(int id)
        {
            _repo.DeleteItem(id);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutItem(Item It)
        {
            _repo.UpdateItem(It);
            return Ok();
        }
       

    }
}
