using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Aceoffix7_NetCore_Simple.Controllers
{

    public class WordController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WordController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            AceoffixNetCore.AceoffixCtrl aceCtrl= new AceoffixNetCore.AceoffixCtrl(Request);
            aceCtrl.SaveFilePage = "Save";
            aceCtrl.WebOpen("/doc/editword.docx", AceoffixNetCore.OpenModeType.docNormalEdit, "tom");
            ViewBag.aceCtrl = aceCtrl.GetHtml();
            return View();
        }

        public async Task<ActionResult> Save()
        {
            AceoffixNetCore.FileSaver fs = new AceoffixNetCore.FileSaver(Request, Response);
            await fs.LoadAsync();
            string webRootPath = _webHostEnvironment.WebRootPath;
            fs.SaveToFile(webRootPath + "/doc/" + fs.FileName);
            return fs.Close();
        }
    }
}
