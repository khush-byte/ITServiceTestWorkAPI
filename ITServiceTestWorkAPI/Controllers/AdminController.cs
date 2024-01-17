using ITServiceTestWorkAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceTestWorkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly List<AdminModel> _admins;

        public AdminController()
        {
            _admins = new List<AdminModel>();
        }

        [HttpGet]
        public IEnumerable<AdminModel> Get()
        {
            return _admins;
        }

        [HttpGet("{id}")]
        public ActionResult<AdminModel> GetById(int id)
        {
            var admin = _admins.FirstOrDefault(t => t.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [HttpPost]
        public ActionResult<AdminModel> Create(AdminModel admin)
        {
            admin.Id = _admins.Count + 1;
            _admins.Add(admin);

            return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AdminModel admin)
        {
            var existingAdmin = _admins.FirstOrDefault(t => t.Id == id);
            if (existingAdmin == null)
            {
                return NotFound();
            }

            existingAdmin.Name = admin.Name;
            existingAdmin.Password = admin.Password;
            existingAdmin.Login = admin.Login;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var admin = _admins.FirstOrDefault(t => t.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            _admins.Remove(admin);

            return NoContent();
        }
    }
}
