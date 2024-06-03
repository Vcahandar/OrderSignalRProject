using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        readonly IFeatureService _featureService;
        readonly IMapper _mapper;
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);


        }


        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Description3 = createFeatureDto.Description3,
                Title3 = createFeatureDto.Title3,

            });

            return Ok("Feature done");
        }

        [HttpDelete]

        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);

            return Ok("Feature Delete");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);

            return Ok(value);
        }


        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Description3 = updateFeatureDto.Description3,
                Title3 = updateFeatureDto.Title3,
                FeatureId = updateFeatureDto.FeatureId
            });

            return Ok("Feature Update");
        }
    }
}
