using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly IContactService _contactService;
        readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);


        }


        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                FooterDesc = createContactDto.FooterDesc,
                Location = createContactDto.Location,
                Mail=createContactDto.Mail,
                Phone=createContactDto.Phone,
                FooterTitle=createContactDto.FooterTitle,
                OpenDays=createContactDto.OpenDays,
                OpenDaysDesc=createContactDto.OpenDaysDesc,
                OpenHours=createContactDto.OpenHours,
                

            });

            return Ok("Contact done");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);

            return Ok("Contact Delete");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);

            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                FooterDesc = updateContactDto.FooterDesc,
                ContactId = updateContactDto.ContactId,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone,
                Location=updateContactDto.Location,
				FooterTitle = updateContactDto.FooterTitle,
				OpenDays = updateContactDto.OpenDays,
				OpenDaysDesc = updateContactDto.OpenDaysDesc,
				OpenHours = updateContactDto.OpenHours,
			});

            return Ok("Contact Update");
        }

    }
}
