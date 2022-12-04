using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCSharp.Model.Entities;

namespace ApiCSharp.Services
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> ListarVeiculos();
        Task<Veiculo> ConsultaVeiculoPorId(int Id);
        void InsereVeiculo(Veiculo veiculo);
        void AtualizaVeiculo(Veiculo veiculo);
        void DeletaVeiculo(int Id);
        Task<bool> SaveChangesAsync();
    }
}