using AutoMapper;
using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Infra.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace CRUD.Web.Controllers
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
        private  void CarregaDropDownList()
        {
            ViewBag.SexoDropDown = new SelectList(sexoService.ColecaoSexo(), "sex_sigla", "sex_nome");
            ViewBag.CargosDropDown = new SelectList( cargoService.ColecaoEFCore(), "car_id", "car_nome");//Preenche DROPDOWNLIST

        }
        // GET: ContatoController
        public async Task<IActionResult> Index()
        {

            return View(await contatoService.ColecaoAsyncEFCore());
        }

        // GET: ContatoController/Create

        public ActionResult Cadastrar()
        {
            CarregaDropDownList();
            return View();
        }

        // POST: ContatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(ContatoViewModel contato)
        {
            if (contato.con_dtNasc.Date >= DateTime.Now.Date)
            {

                ModelState.AddModelError("", "Data de Nascimento não pode ser superior que a data atual.");
            }
                
            if (ModelState.IsValid)
            {
                (bool isValid, string mensagem) = await contatoService.InserirAsyncEFCore(contato);
                if (!isValid)
                {
                    ModelState.AddModelError("", mensagem);
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        // GET: ContatoController/Edit/5
        public async Task<ActionResult> Editar(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var objeto = await contatoService.ObjetoPorIdAsyncEFCore((int)id);
            if (objeto == null)
            {
                return NotFound();
            }
            return View(objeto);
        }

        // POST: ContatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, [Bind("con_id,con_nome,con_telefone,con_sexo,con_ativo,car_id")] ContatoViewModel contato)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, [Bind("con_id,con_nome,con_telefone,con_sexo,con_ativo,car_id")] ContatoViewModel contato)
        {
            var objeto = await contatoService.ObjetoPorIdAsyncEFCore(id);
            await contatoService.ExcluirAsyncEFCore(objeto);

            return RedirectToAction(nameof(Index));
        }
    }
}
