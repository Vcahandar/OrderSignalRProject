using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        readonly ISliderService _sliderService;
		readonly IMapper _mapper;

		public SlidersController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService  = sliderService;
			_mapper = mapper;

		}

		[HttpGet]
        public IActionResult Sliderlist()
        {
            return Ok(_sliderService.TGetListAll());
        }


		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			var sliderEntity = _mapper.Map<Slider>(createSliderDto);

			_sliderService.TAdd(sliderEntity);

			return Ok("Slider done");
		}




		[HttpDelete("{id}")]

		public IActionResult DeleteSlider(int id)
		{
			var value = _sliderService.TGetById(id);
			
			_sliderService.TDelete(value);

			return Ok("Slider Delete");
		}


		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			var value = _sliderService.TGetById(id);

			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var existingSlider = _sliderService.TGetById(updateSliderDto.SliderId);
			if (existingSlider == null)
			{
				return NotFound("Slider not found");
			}

			_mapper.Map(updateSliderDto, existingSlider);

			_sliderService.TUpdate(existingSlider);

			return Ok("Slider updated");
		}


	}
}
