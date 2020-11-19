using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Recibos.Api.Response;
using Recibos.Core.DTOs;
using Recibos.Core.Entities;
using Recibos.Core.Interfaces;

namespace Recibos.Api.Controllers
{
    [EnableCors("_corsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;
        private readonly IMapper _mapper;
        public ReceiptController(IReceiptService receiptService, IMapper mapper)
        {
            _receiptService = receiptService;
            _mapper = mapper;
        }

        // GET: api/<ReceiptController> 
        [HttpGet]
        public IActionResult Get()
        {
            var result = _receiptService.GetReceipt();
            var resultDto = _mapper.Map<IEnumerable<ReceiptDto>>(result);
            var response = new ApiResponse<IEnumerable<ReceiptDto>>(resultDto);

            return Ok(response);
        }

        // GET api/<ReceiptController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _receiptService.GetReceipt(id);
            var resultDto = _mapper.Map<ReceiptDto>(result);
            var response = new ApiResponse<ReceiptDto>(resultDto);
            return Ok(response);
        }

        // POST api/<ReceiptController>
        [HttpPost]
        public async Task<IActionResult> Post(ReceiptDto receiptDto)
        {
            var receipt = _mapper.Map<Receipt>(receiptDto);
            await _receiptService.AddReceipt(receipt);

            receiptDto = _mapper.Map<ReceiptDto>(receipt);
            var response = new ApiResponse<ReceiptDto>(receiptDto);
            return Ok(response);
        }

        // PUT api/<ReceiptController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ReceiptDto receiptDto)
        {
            var receipt = _mapper.Map<Receipt>(receiptDto);
            receipt.Id = id;

            var result  = await _receiptService.UpdateReceipt(receipt);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE api/<ReceiptController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            var result = await _receiptService.DeleteReceipt(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
