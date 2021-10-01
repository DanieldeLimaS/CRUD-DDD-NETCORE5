using AutoMapper;
using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Infra.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CRUD.Web.Controllers
{
    [Authorize]
    public class ContatoController : Controller
    {
        private IContatoService contatoService;
        private ICargoService cargoService;
        private readonly IMapper mapper;

        public ContatoController(IContatoService _contatoService,
                                 ICargoService _cargoService, IMapper _mapper)
        {
            contatoService = _contatoService;
            cargoService = _cargoService;
            mapper = _mapper;
        }
        private async void CarregaDropDownList()
        {
            ViewBag.SexoDropDown = new[]
        {
                    new SelectListItem(){ Value = "1", Text = "Masculino"},
                    new SelectListItem(){ Value = "2", Text = "Feminino"},
                    new SelectListItem(){ Value = "3", Text = "Prefiro não informar"}
                };
            ViewBag.CargosDropDown = new SelectList(await cargoService.ColecaoAsyncEFCore(), "car_id", "car_nome");//Preenche DROPDOWNLIST

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
        public async Task<ActionResult> Cadastrar([Bind("con_id,con_nome,con_telefone,con_sexo,con_ativo,car_id")] ContatoViewModel contato)
        {
            if (ModelState.IsValid)
            {
                await contatoService.InserirAsyncEFCore(contato);
                return RedirectToAction(nameof(Index));
            }
            return View(contato);

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
