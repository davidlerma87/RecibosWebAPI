using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recibos.Api.Response;
using Recibos.Core.DTOs;
using Recibos.Core.Entities;
using Recibos.Core.Interfaces;

namespace Recibos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;
        public CurrencyController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }
        // GET: api/<CurrencyController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _currencyService.GetCurrencies();
            var resultDto = _mapper.Map<IEnumerable<CurrencyDto>>(result);
            var response = new ApiResponse<IEnumerable<CurrencyDto>>(resultDto);

            return Ok(response);
        }

        // GET api/<CurrencyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currencyService.GetCurrency(id);
            var resultDto = _mapper.Map<CurrencyDto>(result);
            var response = new ApiResponse<CurrencyDto>(resultDto);
            return Ok(response);
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public async Task<IActionResult> Post(CurrencyDto currencyDto)
        {
            var currency = _mapper.Map<Currency>(currencyDto);
            await _currencyService.AddCurrency(currency);

            currencyDto = _mapper.Map<CurrencyDto>(currency);
            var response = new ApiResponse<CurrencyDto>(currencyDto);
            return Ok(response);
        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CurrencyDto currencyDto)
        {
            var currency = _mapper.Map<Currency>(currencyDto);
            currency.Id = id;

            var result = await _currencyService.UpdateCurrency(currency);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currencyService.DeleteCurrency(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
