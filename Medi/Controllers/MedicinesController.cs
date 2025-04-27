using Medi.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Medi.API.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Medi.Core.Models;

namespace Medi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MedicineResponse>>> GetMedicines()
        {
            var medicines = await _medicineService.GetAllMedicines();

            var response = medicines.Select(m => new MedicineResponse(m.Id, m.Name, m.Description, m.Form));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMedicine([FromBody] MedicineRequest request)
        {
            var (medicine, error) = Medicine.Create(Guid.NewGuid(), request.name, request.description, request.form);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var medicineId = await _medicineService.CreateMedicine(medicine);

            return Ok(medicineId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateMedicine(Guid id, [FromBody] MedicineRequest request)
        {
            var medicineId = await _medicineService.UpdateMedicine(id, request.name, request.description, request.form);

            return Ok(medicineId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteMedicine (Guid id)
        {
            return Ok(await _medicineService.DeleteMedicine(id));
        }
    }
}
