using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCSharp.Model.Entities;
using ApiCSharp.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCSharp.Services
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly VeiculoContext _veiculoContext;

        public VeiculoRepository(VeiculoContext veiculoContext)
        {
            _veiculoContext = veiculoContext;
        }

        public void AtualizaVeiculo(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public async Task<Veiculo> ConsultaVeiculoPorId(int Id)
        {
            return await _veiculoContext.Veiculos.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public void DeletaVeiculo(int Id)
        {
            throw new NotImplementedException();
        }

        public void InsereVeiculo(Veiculo veiculo)
        {
            _veiculoContext.Add(veiculo);
        }

        public async Task<IEnumerable<Veiculo>> ListarVeiculos()
        {
            var veiculos = _veiculoContext.Veiculos.ToListAsync();
            return await veiculos;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _veiculoContext.SaveChangesAsync() > 0;
        }
    }
}