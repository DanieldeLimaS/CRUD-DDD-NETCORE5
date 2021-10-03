using CRUD.Domain.DTOs;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using CRUD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        public AppDbContext context;
        public ContatoRepository(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<(bool, string)> AtualizarObjetoEFCore(CAD_contato cAD_contato)
        {
            try
            {
                context.CAD_contato.Update(cAD_contato);
                await context.SaveChangesAsync();
                return (true, "Contato Atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Ocorreu um erro interno\n{ex.Message}");
            }
        }

        public async Task<List<ContatoDTO>> ColecaoEFCore(string pesquisa = "")
        {
            try
            {
                List<ContatoDTO> colecao = await context.CAD_contato
                    .AsNoTracking()
                     .Where(x => x.con_nome.Contains(pesquisa))
                    .Select(x => new ContatoDTO
                    {
                        con_id = x.con_id,
                        con_ativo = x.con_ativo,
                        car_nome = x.cAD_cargo.car_nome,
                        car_id = x.car_id,
                        con_dtNasc = x.con_dtNasc,
                        con_nome = x.con_nome,
                        con_sexo = x.con_sexo,
                        con_telefone = x.con_telefone
                    })
                    .ToListAsync();
                return colecao;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(bool, string)> ExcluirObjetoEFCore(int id)
        {
            try
            {
                CAD_contato cAD_contato = await context.CAD_contato.FindAsync(id);
                context.CAD_contato.Remove(cAD_contato);
                await context.SaveChangesAsync();
                return (true, "Contato Excluido com sucesso");
            }
            catch (Exception ex)
            {
                return (false, $"Ocorreu um erro interno\n{ex.Message}");
            }
        }

        public async Task<CAD_contato> ObjetoPorIdEFCore(int id)
        {
            return await context.CAD_contato.FindAsync(id);
        }

        public async Task<(bool, string)> InserirEFCore(CAD_contato cAD_contato)
        {
            try
            {
                context.CAD_contato.Add(cAD_contato);
                await context.SaveChangesAsync();
                return (true, "Contato cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return (false, $"Ocorreu um erro interno\n{ex.Message}");
            }
        }
    }
}
