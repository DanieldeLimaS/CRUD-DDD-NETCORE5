using AutoMapper;
using CRUD.Application.Services;
using CRUD.Application.ViewModels;
using CRUD.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRUD.Application.Tests.Services
{
    public class ContatoServiceTests
    {
        private ContatoService contatoService;
        public ContatoServiceTests()
        {
            contatoService = new ContatoService(new Mock<IContatoRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public async Task Post_cadastrar_novo_contato()
        {
            var exception = await Assert.ThrowsAsync<ValidationException>(() => contatoService.InserirAsyncEFCore(new ContatoViewModel
            {
                con_dtNasc = DateTime.Now.AddDays(-5),
                con_nome=@"''_234"
            }));
            Assert.Equal("Error", exception.Message);
        }
        [Fact]
        public void Post_atualizar_contato()
        {
            Assert.True(true);
        }
    }
}
