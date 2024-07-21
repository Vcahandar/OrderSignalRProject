using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message Message = new Message()
            {
                NameSurname = createMessageDto.NameSurname,
                Subject = createMessageDto.Subject,
                Email = createMessageDto.Email,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                Status =false,
            };

            _messageService.TAdd(Message);
            return Ok("Message section successfully added!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetById(id);
            _messageService.TDelete(values);
            return Ok("Message me field has been deleted!");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message Message = new Message()
            {
                MessageId= updateMessageDto.MessageId,
                NameSurname = updateMessageDto.NameSurname,
                Subject = updateMessageDto.Subject,
                Email = updateMessageDto.Email,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                Status = false,
            };

            _messageService.TUpdate(Message);
            return Ok("Message area has been updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }


		[HttpGet("MessageCountByStatusFalse")]
		public IActionResult MessageCountByStatusFalse()
		{
			return Ok(_messageService.TMessageCountByStatusFalse());
		}


		[HttpGet("GetAllMessageByFalse")]
		public IActionResult GetAllMessageByFalse()
		{
			return Ok(_messageService.TGetAllMessageByFalse());
		}

		[HttpGet("MessageChangeToFalse/{id}")]
		public IActionResult MessageChangeToFalse(int id)
		{
			_messageService.TMessageChangeToFalse(id);
			return Ok("Update False Done");
		}


		[HttpGet("MessageChangeToTrue/{id}")]
		public IActionResult MessageChangeToTrue(int id)
		{
			_messageService.TMessageChangeToTrue(id);
			return Ok("Update True Done");
		}
	}
}
