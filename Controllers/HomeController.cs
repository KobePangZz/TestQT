using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _Env;
        // GET: HomeController
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment Env)
        {
            _logger = logger;
            _Env = Env;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var path = _Env.ContentRootPath;
            path += "\\Sequence.json";
            string json = await System.IO.File.ReadAllTextAsync(path);
            var model = JsonSerializer.Deserialize<List<SequenceOption>>(json);
            return Json(model);
        }
        // POST: HomeController/Create
        [HttpPost]
        public async Task<JsonResult> Post(string name, string cmd)
        {
            try
            {
                var path = _Env.ContentRootPath;
                path += "\\Sequence.json";
                string json = await System.IO.File.ReadAllTextAsync(path);
                var model = JsonSerializer.Deserialize<List<SequenceOption>>(json);
                var item = new SequenceOption
                {
                    Id = model.LastOrDefault().Id + 1,
                    Name = name,
                    Cmd = cmd,
                    Checked = true,
                    Result = 0
                };
                model.Add(item);
                await System.IO.File.WriteAllTextAsync(path, JsonSerializer.Serialize(model));
                return Json(new { ok = true, data = item });
            }
            catch (System.Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message });
            }
        }

    }
}
