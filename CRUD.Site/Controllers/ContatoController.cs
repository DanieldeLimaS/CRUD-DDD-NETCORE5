using AutoMapper;
using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Infra.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Site.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        private IContatoService contatoService;
        private ICargoService cargoService;
        private ISexoService sexoService;
        private readonly IMapper mapper;

        public ContatoController(IContatoService _contatoService,
                                 ICargoService _cargoService,
                                 ISexoService _sexoService, IMapper _mapper)
        {
            contatoService = _contatoService;
            cargoService = _cargoService;
            sexoService = _sexoService;
            mapper = _mapper;

        }
        private void CarregaDropDownList()
        {
            ViewData["SexoDropDown"] = new SelectList(sexoService.ColecaoSexo(), "sex_sigla", "sex_nome");
            ViewData["CargosDropDown"] = new SelectList(cargoService.ColecaoEFCore(), "car_id", "car_nome");//Preenche DROPDOWNLIST

        }
        // GET: ContatoController
        public async Task<IActionResult> Index()
        {
            return View(await contatoService.ColecaoAsyncEFCore());
        }
        [HttpGet]
        public async Task<IActionResult> Pesquisar(string pesquisa)
        {
            if (string.IsNullOrEmpty(pesquisa))
                pesquisa = string.Empty;
            var Colecao = await contatoService.ColecaoAsyncEFCore(pesquisa);
            if (Colecao is null)
                return Ok(Json(new { erro = "Dados não encontrados" }));
            return Ok(Json(new { dados = Colecao }));

        }

        // GET: ContatoController/Create

        public ActionResult Cadastrar()
        {
            CarregaDropDownList();
            return View();
        }
        private void ValidaContato(ContatoViewModel contato)
        {
            if (contato.con_dtNasc.Date >= DateTime.Now.Date)
                ModelState.AddModelError("", "Data de Nascimento não pode ser superior ou igual a data atual.");
        }
        // POST: ContatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(ContatoViewModel contato)
        {
            if (await Salvar(EInserirAtualizar.INSERIR, contato))
                return RedirectToAction(nameof(Index));
            return View();
        }

        // GET: ContatoController/Edit/5
        public async Task<ActionResult> Editar(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            CarregaDropDownList();
            var objeto = await contatoService.ObjetoPorIdAsyncEFCore((int)id);
            if (objeto == null)
            {
                return NotFound();
            }
            return View(objeto);
        }
        private async Task<bool> Salvar(EInserirAtualizar operacao, ContatoViewModel contato)
        {
            ValidaContato(contato);
            if (!ModelState.IsValid)
                return false;

            (bool isValid, string mensagem) = operacao == EInserirAtualizar.ATUALIZAR ?
                                                        await contatoService.AtualizarAsyncEFCore(contato) :
                                                         await contatoService.InserirAsyncEFCore(contato);
            if (!isValid)
            {
                ModelState.AddModelError("", mensagem);
                return false;
            }

            return true;
        }
        // POST: ContatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? id, ContatoViewModel contato)
        {
            contato.con_id = (int)id;
            if (await Salvar(EInserirAtualizar.ATUALIZAR, contato))
                return RedirectToAction(nameof(Index));
            return Ok(Json("dados atualizados"));

        }

        // GET: ContatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            var objeto = await contatoService.ObjetoPorIdAsyncEFCore((int)id);

            (bool isValid, string mensagem) = await contatoService.ExcluirAsyncEFCore(objeto);

            return Ok(Json(new { op = isValid, msg = mensagem }));
        }
    }
}
