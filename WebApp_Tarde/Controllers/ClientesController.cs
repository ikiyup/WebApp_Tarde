 using Microsoft.AspNetCore.Mvc;
using WebApp_Tarde.Models;

namespace WebApp_Tarde.Controllers
{
    public class ClientesController : Controller
    {
        public static List<ClientesViewModel> db = new List<ClientesViewModel>();

        public IActionResult Lista()
        {
            ClientesViewModel c1 = new ClientesViewModel();
            c1.Id = 1;
            c1.Telefone = "992601618";
            c1.Nome = "Lucas";

            for (int i = 0; i < 10; i++)
            {
                ClientesViewModel c2 = new ClientesViewModel();
                c2.Id = i;
                c2.Nome = "Cliente " + i;
                c2.Telefone = "Telefone " + i;

                db.Add(c2);
            }

            db.Add(c1);
            return View( db );
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalvarDados(ClientesViewModel dados)
        {
            if(dados.Id == 0)
            {
                Random rand = new Random();
                int numeroAleatorio = rand.Next(1, 9999);
                //Gerando Id aleatório
                dados.Id = numeroAleatorio;
                //Adicionando os dados no banco
                db.Add(dados);
            }
            return RedirectToAction("Lista");
        }
    }
}
