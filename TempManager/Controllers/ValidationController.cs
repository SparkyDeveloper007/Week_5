using TempManager.Models;
using Microsoft.AspNetCore.Mvc;


namespace TempManager.Controllers;

public class ValidationController : Controller
{
    private readonly TempManagerContext _context;

    public ValidationController(TempManagerContext context)
    {
        _context = context;
    }

    public JsonResult CheckDate(string date)
    {
        if (DateTime.TryParse(date, out DateTime parsedDate))
        {
            bool dateExists = _context.Temps.Any(t => t.Date.HasValue && t.Date.Value.Date == parsedDate.Date);

            if (dateExists)
            {
                return Json("This date has already been entered into the system");

            }
        }

        return Json(true);
    }
   
    
    
}