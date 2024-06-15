using Api.Models;
using Api.Models.DTO;
using Api.Models.Enum;
using Api.Models.Generic;
using Api.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        private readonly IHumanoRepository _humanoRepository;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public HumanoController(IHumanoRepository humanoRepository, IMapper mapper)
        {
            _humanoRepository = humanoRepository;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet("GetAllMock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllMock()
        {
            try
            {

                var humanosMuck = await _humanoRepository.HumanosList();

                _response.Result = _mapper.Map<List<Tbl_HumanoDTO>>(humanosMuck);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost("AplicaOperacionPost")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> AplicaOperacionPost([FromBody] MatematicsParams matematicsParams)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                _response.Result = await _humanoRepository.CalculateOperation(matematicsParams.operation,matematicsParams.num1,matematicsParams.num2);
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("AplicaOperacionGet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> AplicaOperacionGet(
                [FromHeader(Name = "Operand1")] double operand1,
                [FromHeader(Name = "Operand2")] double operand2,
                [FromHeader(Name = "Operator")] OperationType operatorValue
            )
        {
            try
            {
               
                double result = await _humanoRepository.CalculateOperation(operatorValue,operand1,operand2);

                _response.Result = result;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearHumano([FromBody] Tbl_HumanoDTO createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                var modelo = _mapper.Map<Tbl_Humano>(createDto);

                await _humanoRepository.Create(modelo);
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateHumano([FromBody] Tbl_HumanoDTO updateDto)
        {
            if (updateDto == null || updateDto.Id < 1 || await _humanoRepository.Get(v => v.Id == updateDto.Id, false) == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var modelo = _mapper.Map<Tbl_Humano>(updateDto);


            await _humanoRepository.Update(modelo);
            _response.StatusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {

                var humanoList = await _humanoRepository.GetAll();

                _response.Result = _mapper.Map<List<Tbl_HumanoDTO>>(humanoList);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetHumano")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetHumano(int id)
        {
            try
            {

                var humano = await _humanoRepository.Get(e => e.Id == id);

                _response.Result = _mapper.Map<Tbl_HumanoDTO>(humano);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
