using appSatTech.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appReversotask.Controllers
{
    // Controller responsável pelo gerenciamento de chamados técnicos (CRUD)
    public class ChamadoController : Controller
    {
        // Contexto do banco de dados (Entity Framework Core)
        private readonly DbTecnicoContext _context;

        // Injeção de dependência do DbContext
        public ChamadoController(DbTecnicoContext context)
        {
            _context = context;
        }

        // GET: Chamado - Lista os chamados do cliente autenticado
        public async Task<IActionResult> Index()
        {
            // Extrai o ID do cliente logado através das Claims de autenticação
            var clienteIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Valida se o ID existe e é um número inteiro válido; caso contrário, redireciona para o login
            if (string.IsNullOrEmpty(clienteIdClaim) || !int.TryParse(clienteIdClaim, out int clienteId))
            {
                return RedirectToAction("Login", "Account");
            }

            // Busca apenas os chamados associados ao cliente logado, incluindo os dados de Tecnico e Cliente (Eager Loading)
            var chamados = await _context.Chamados
                .Include(c => c.Tecnico)
                .Include(c => c.Cliente)
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();

            return View(chamados);
        }

        // GET: Chamado/Details/5 - Exibe os detalhes de um chamado específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Carrega o chamado especificado pelo ID com seus relacionamentos
            var chamado = await _context.Chamados
                .Include(c => c.Tecnico)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Codigo == id);

            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamado/Create - Exibe o formulário para agendar um novo chamado
        public IActionResult Create()
        {
            // Popula as dropdown lists para seleção de técnico e cliente na View
            ViewData["TecnicoId"] = new SelectList(_context.Tecnicos, "Codigo", "Nome");
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Codigo", "Nome");
            return View();
        }

        // POST: Chamado/Create - Processa a criação de um novo chamado
        [HttpPost]
        [ValidateAntiForgeryToken] // Proteção contra ataques CSRF
        public async Task<IActionResult> Create([Bind("DataHora,StatusAtendimento,TecnicoId")] Chamado chamado)
        {
            // Obtém o ID do cliente através da Session ativa
            var clienteId = HttpContext.Session.GetInt32("ClienteId");

            if (clienteId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Associa o chamado ao cliente logado antes da persistência
            chamado.ClienteId = clienteId.Value;

            // Se a validação do modelo for bem-sucedida, salva no banco de dados
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se houver erros de validação, recarrega o dropdown de técnicos e mantém os dados digitados
            ViewData["TecnicoId"] = new SelectList(_context.Tecnicos, "Codigo", "Nome", chamado.TecnicoId);
            return View(chamado);
        }

        // GET: Chamado/Edit/5 - Exibe o formulário de edição de chamado
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }

            // Popula as listas de seleção mantendo o item atual selecionado
            ViewData["TecnicoId"] = new SelectList(_context.Tecnicos, "Codigo", "Codigo", chamado.TecnicoId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Codigo", "Codigo", chamado.ClienteId);
            return View(chamado);
        }

        // POST: Chamado/Edit/5 - Salva as alterações de um chamado existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,DataHora,StatusAtendimento,ClienteId,TecnicoId")] Chamado chamado)
        {
            // Valida se o ID da URL corresponde ao ID do objeto recebido
            if (id != chamado.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Trata exceção de concorrência verificando se o chamado ainda existe
                    if (!ChamadoExists(chamado.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["TecnicoId"] = new SelectList(_context.Tecnicos, "Codigo", "Codigo", chamado.TecnicoId);
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Codigo", "Codigo", chamado.ClienteId);
            return View(chamado);
        }

        // GET: Chamado/Delete/5 - Exibe a tela de confirmação para exclusão de chamado
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamados
                .Include(c => c.Tecnico)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Codigo == id);

            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamado/Delete/5 - Executa a remoção do chamado do banco de dados
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamado = await _context.Chamados.FindAsync(id);
            if (chamado != null)
            {
                _context.Chamados.Remove(chamado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar para checar a existência de um chamado no banco pelo ID
        private bool ChamadoExists(int id)
        {
            return _context.Chamados.Any(e => e.Codigo == id);
        }
    }
}
