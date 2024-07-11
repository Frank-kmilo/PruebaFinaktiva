using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaFinaktiva.Api.Controllers
{
    [Produces("aplication/json")]
    [Route("api/")]
    public class EventLogController : Controller
    {        
        public ActionResult GetAllEvents()
        {
            return View();
        }
       
        /*
        [HttpPost]
        [Route("add-log")]
        public async Task<string>  AddLogAsync()
        {
            return await "";
        }
      
        public async Task<string> GetEvent(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
