using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recibos.Api.Controllers.Response;
using Recibos.Core.DTOs;
using Recibos.Core.Entities;
using Recibos.Core.Interfaces;

namespace Recibos.Api.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _supplierService.GetSuppliers();
            var resultDto = _mapper.Map<IEnumerable<SupplierDto>>(result);
            var response = new ApiResponse<IEnumerable<SupplierDto>>(resultDto);

            return Ok(response);
        }

        // GET api/<CurrencyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _supplierService.GetSupplier(id);
            var resultDto = _mapper.Map<SupplierDto>(result);
            var response = new ApiResponse<SupplierDto>(resultDto);
            return Ok(response);
        }

        // POST api/<CurrencyController>
        [HttpPost]
        public async Task<IActionResult> Post(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            await _supplierService.AddSupplier(supplier);

            supplierDto = _mapper.Map<SupplierDto>(supplier);
            var response = new ApiResponse<SupplierDto>(supplierDto);
            return Ok(response);
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            supplier.Id = id;

            var result = await _supplierService.UpdateSupplier(supplier);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.DeleteSupplier(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
