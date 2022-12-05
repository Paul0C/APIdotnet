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
                : BadRequest("Veículo não adicionado.");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] Veiculo veiculo)
        {
            var veiculoDoBanco = await _veiculoRepository.ConsultaVeiculoPorId(Id);
            if (veiculoDoBanco == null) return NotFound("Veículo não encontrado.");

            veiculoDoBanco.Marca = veiculo.Marca == null ? veiculoDoBanco.Marca : veiculo.Marca;
            veiculoDoBanco.Modelo = veiculo.Modelo == null ? veiculoDoBanco.Modelo : veiculo.Modelo;
            veiculoDoBanco.Ano = veiculo.Ano ?? veiculoDoBanco.Ano;

            _veiculoRepository.AtualizaVeiculo(veiculoDoBanco);
            return await _veiculoRepository.SaveChangesAsync()
                ? Ok("Veículo atualizado com sucesso!")
                : BadRequest("Não foi possível atualizar o véiculo informado.");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            _veiculoRepository.DeletaVeiculo(Id);
            return await _veiculoRepository.SaveChangesAsync()
                ? Ok("Veículo removido com sucesso!")
                : BadRequest("Não foi possível remover o véiculo informado.");
        }
    }
}