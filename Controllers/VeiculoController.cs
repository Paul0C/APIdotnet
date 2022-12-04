using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiCSharp.Services;
using ApiCSharp.Model.Entities;

namespace ApiCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var veiculos = await _veiculoRepository.ListarVeiculos();
            return veiculos != null
                   ? Ok(veiculos)
                   : BadRequest("Não foi possível listar os veículos.");
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetByID(int Id)
        {
            var veiculo = await _veiculoRepository.ConsultaVeiculoPorId(Id);
            return veiculo != null
                   ? Ok(veiculo)
                   : BadRequest("Não foi possível consultar o veículo informado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Veiculo veiculo)
        {
            _veiculoRepository.InsereVeiculo(veiculo);
            return await _veiculoRepository.SaveChangesAsync()
                ? Ok("Veículo adicionado com sucesso!")
                : BadRequest("Usuário não adicionado.");
        }
    }
}