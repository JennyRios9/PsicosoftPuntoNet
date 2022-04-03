using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsicosoftPuntoNet.Datos;
using PsicosoftPuntoNet.Models;

namespace PsicosoftPuntoNet.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PacienteController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: PacienteController
        public List<Pacientes> ListadoGeneralDePacientes()
        {
            return new List<Pacientes>()
            {
                new Pacientes
                {
                    Nombre = "Santiago",
                    Apellido = "Ospina",
                    Cedula = "10261874",
                    Edad = 25,
                    Acudiente = "Gloria",
                    Direccion = "Calle 13",
                    telefono = "2895478"
                },
                 new Pacientes
                {
                    Nombre = "Leon",
                    Apellido = "Murillo",
                    Cedula = "854796",
                    Edad = 35,
                    Acudiente = "Marta",
                    Direccion = "carrera 49",
                    telefono = "3214578"
                },
                  new Pacientes
                {
                    Nombre = "Carlos",
                    Apellido = "Motoa",
                    Cedula = "10361485",
                    Edad = 25,
                    Acudiente = "Adriana",
                    Direccion = "Calle 58",
                    telefono = "274528"
                },
                   new Pacientes
                {
                    Nombre = "Pablo",
                    Apellido = "Gomez",
                    Cedula = "745896",
                    Edad = 45,
                    Acudiente = "Ligia",
                    Direccion = "carrera 98",
                    telefono = "3214587"
                },
                    new Pacientes
                {
                    Nombre = "Oscar",
                    Apellido = "Montoya",
                    Cedula = "254781",
                    Edad = 50,
                    Acudiente = "Emilse",
                    Direccion = "Calle 132 a sur",
                    telefono = "2784517"
                },
                     new Pacientes
                {
                    Nombre = "Andres",
                    Apellido = "Tamayo",
                    Cedula = "312458",
                    Edad = 20,
                    Acudiente = "Margarita",
                    Direccion = "Carrera 50",
                    telefono = "258743"
                }
            };
        }

        // GET: PacientesController

        public async Task<IActionResult> ListadoPacientes()
        {
            //Almaceno en la variable *list_pacientes la lista de productos*
            //var list_Pacientes = ListadoGeneralDePacientes();

            //Obtengo las pacientes de la base de datos
            var listaPacientes = await _db.Paciente.ToListAsync();

            //Realizo una instancia de la clase que contiene la lista de pacientes
            var modeloPacientes = new PacientesIndexModelView();

            //Lleno el atributo de la clase PacienteIndexModelView --> ListadoDePaciente
            //La lleno con la variable que contiene el listado creado arriba
            modeloPacientes.Listado_de_pacientes = listaPacientes;

            return View(modeloPacientes);
        }

        // GET: PacienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacienteController/Create
        public ActionResult Registrar()
        {
            return View();
        }

        // POST: PacienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(Pacientes paciente)
        {
            if (ModelState.IsValid)
            {
                _db.Paciente.Add(paciente); 
                _db.SaveChanges();
                return RedirectToAction("ListadoPacientes");   
            }
            return View();
        }

        // GET: PacienteController/Edit/5
        public ActionResult Editar(int id)
        {
            if (id != 0)
            {
                var paciente = _db.Paciente.Find(id);
                if (paciente != null)
                {
                    return View(paciente);
                }
               
            }
            return NotFound(); 
        }

        // POST: PacienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Pacientes paciente)
        {
           if (ModelState.IsValid)
            {
                _db.Paciente.Update(paciente);
                _db.SaveChanges();
                return RedirectToAction("ListadoPacientes");
            }
           return View(paciente);   

        }

        // GET: PacienteController/Delete/5
        public ActionResult Eliminar(int id)
        {
            if (id != 0)
            {
                var paciente = _db.Paciente.Find(id);
                if (paciente != null)
                {
                    return View(paciente);
                }

            }
            return NotFound();
        }

        // POST: PacienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Pacientes paciente)
        {
            if (paciente != null)
            {
                _db.Paciente.Remove(paciente);
                _db.SaveChanges();
                return RedirectToAction("ListadoPacientes");
            }
            return NotFound();
        }
    }
}
