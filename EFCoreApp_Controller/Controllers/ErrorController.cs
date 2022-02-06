using System.Diagnostics;
using EFCoreApp_Model.Models;
using Microsoft.AspNetCore.Mvc;
namespace EFCoreApp_Controller.Controllers;
public class ErrorController : Controller
{

    [Route("error/{code:int}")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int code)
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier ,StatusCode = code});
    }

    // [Route("error/{code:string}")]
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error(string code)
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier ,StatusCode = HttpContext.Response.StatusCode});
    // }
}
