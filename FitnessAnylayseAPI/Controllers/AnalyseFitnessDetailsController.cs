using FitnessAnylayseAPI.Model;
using FitnessAnylayseAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessAnylayseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyseFitnessDetailsController : Controller
    {
        
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetWorkOutDetailsByEmail(string email)
        {
            // Create an instance of the FitnessAnalysisService
            FitnessAnalysisService fitnessAnalysisService = new FitnessAnalysisService();

            // Asynchronously invoke the analyseDataByMail method using Task.Run
            AnalyseData analyseData = await Task.Run(() => fitnessAnalysisService.anylszeDataByMail(email));

            return Ok(analyseData);
        }

    }
}
