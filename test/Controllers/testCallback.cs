using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [Route("test/[controller]")]
    [ApiController]
    public class testCallback : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDataWithCallback()
        {
            return await LongRunningOperationWithCallback((result) =>
            {
                // Это коллбэк функция, которая будет вызвана после завершения длительной операции
                return Ok($"Результат работы: {result}");
            });
        }

        private async Task<IActionResult> LongRunningOperationWithCallback(Func<string, IActionResult> callback)
        {
            await Task.Delay(5000); // Симуляция длительной операции

            string result = "Длительная операция завершена";

            // Вызов коллбэка с результатом операции
            return callback(result);
        }
    }
}
