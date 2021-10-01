using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using CRUD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<CAD_contato>> ColecaoEFCore()
        {
            return await context.CAD_contato.ToListAsync();
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
            catch(Exception ex)
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
                await context.Set<CAD_contato>().AddAsync(cAD_contato);
                await context.SaveChangesAsync();
                return (true, "Contato cadastrado com sucesso");
            }
            catch(Exception ex)
            {
                return (false, $"Ocorreu um erro interno\n{ex.Message}");
            }
        }
    }
}
