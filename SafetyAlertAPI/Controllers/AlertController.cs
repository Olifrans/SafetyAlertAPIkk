using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafetyAlertAPI.Data;
using SafetyAlertAPI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;




namespace SafetyAlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {





        /// <summary>
        /// Exemplo 01 - ok
        /// </summary>
        /// <param name = "alert" ></ param >
        /// < returns ></ returns >

        private readonly AlertContext _context;
        private readonly IWebHostEnvironment _environment;

        public AlertController(AlertContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("trigger")]
        public async Task<IActionResult> TriggerAlert([FromForm] IFormFile video, [FromForm] string location)
        {
            var alert = new Alert
            {
                TimeStamp = DateTime.UtcNow,
                Location = location,
                AudioFilePath = string.Empty, // Atualize para capturar o caminho do áudio se necessário
                VideoFilePath = string.Empty
            };

            if (video != null)
            {
                var videoPath = Path.Combine(_environment.WebRootPath, "uploads", $"{Guid.NewGuid()}.mp4");
                using (var stream = new FileStream(videoPath, FileMode.Create))
                {
                    await video.CopyToAsync(stream);
                    alert.VideoFilePath = videoPath;
                }
            }

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Alerta acionado com sucesso", Alert = alert });
        }






        ///// <summary>
        ///// Exemplo 02 - ok
        ///// </summary>
        ///// <param name = "alert" ></ param >
        ///// < returns ></ returns >
        //private readonly AlertContext _context;
        //private readonly IWebHostEnvironment _environment;

        //public AlertController(AlertContext context, IWebHostEnvironment environment)
        //{
        //    _context = context;
        //    _environment = environment;
        //}

        //[HttpPost("trigger")]
        //public async Task<IActionResult> TriggerAlert([FromForm] IFormFile video, [FromForm] string location)
        //{
        //    var alert = new Alert
        //    {
        //        TimeStamp = DateTime.UtcNow,
        //        Location = location,
        //        AudioFilePath = string.Empty, // Atualize para capturar o caminho do áudio se necessário
        //        VideoFilePath = string.Empty
        //    };

        //    if (video != null)
        //    {
        //        var videoPath = Path.Combine(_environment.WebRootPath, "uploads", $"{Guid.NewGuid()}.mp4");
        //        using (var stream = new FileStream(videoPath, FileMode.Create))
        //        {
        //            await video.CopyToAsync(stream);
        //            alert.VideoFilePath = videoPath;
        //        }
        //    }

        //    _context.Alerts.Add(alert);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { Message = "Alerta acionado com sucesso", Alert = alert });





        ///// <summary>
        ///// Exemplo 03 - ok
        ///// </summary>
        ///// <param name="alert"></param>
        ///// <returns></returns>
        //private readonly AlertContext _context;
        //private readonly IWebHostEnvironment _environment;

        //public AlertController(AlertContext context, IWebHostEnvironment environment)
        //{
        //    _context = context;
        //    _environment = environment;
        //}

        //[HttpPost("trigger")]
        //public async Task<IActionResult> TriggerAlert([FromForm] IFormFile video, [FromForm] string location)
        //{
        //    var alert = new Alert
        //    {
        //        TimeStamp = DateTime.UtcNow,
        //        Location = location,
        //        VideoFilePath = string.Empty
        //    };

        //    if (video != null)
        //    {
        //        var videoPath = Path.Combine(_environment.WebRootPath, "uploads", $"{Guid.NewGuid()}.mp4");
        //        using (var stream = new FileStream(videoPath, FileMode.Create))
        //        {
        //            await video.CopyToAsync(stream);
        //            alert.VideoFilePath = videoPath;
        //        }
        //    }

        //    _context.Alerts.Add(alert);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { Message = "Alerta acionado com sucesso", Alert = alert });
        //}

        /*
         Explicação:
        TriggerAlert: O método que recebe uma requisição POST, contendo o vídeo e as coordenadas de localização. O vídeo é salvo em um diretório específico no servidor, e a localização é armazenada junto com o caminho do vídeo no banco de dados.
         */








        //private readonly AlertContext _context;
        //private readonly ILogger<AlertController> _logger;
        //private readonly IWebHostEnvironment _environment;

        /// <summary>
        ///  /// Exemplo 06 - ok!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <param name="environment"></param>
        //public AlertController(AlertContext context, ILogger<AlertController> logger, IWebHostEnvironment environment)
        //{
        //    _context = context;
        //    _logger = logger;
        //    _environment = environment;
        //}

        //[HttpPost("trigger")]
        //public async Task<IActionResult> TriggerAlert([FromForm] IFormFile video, [FromForm] string location)
        //{
        //    _logger.LogInformation("TriggerAlert called with location: {Location}", location);

        //    if (video == null || string.IsNullOrWhiteSpace(location))
        //    {
        //        _logger.LogWarning("Video or location data is missing.");
        //        return BadRequest("Video or location data is missing.");
        //    }

        //    var alert = new Alert
        //    {
        //        TimeStamp = DateTime.UtcNow,
        //        Location = location,
        //        VideoFilePath = string.Empty
        //    };

        //    if (video != null)
        //    {
        //        var videoPath = Path.Combine(_environment.WebRootPath, "uploads", $"{Guid.NewGuid()}.mp4");
        //        using (var stream = new FileStream(videoPath, FileMode.Create))
        //        {
        //            await video.CopyToAsync(stream);
        //            alert.VideoFilePath = videoPath;
        //        }
        //    }

        //    _context.Alerts.Add(alert);
        //    await _context.SaveChangesAsync();

        //    _logger.LogInformation("Alert saved successfully with ID: {AlertId}", alert.Id);
        //    return Ok(new { Message = "Alerta acionado com sucesso", Alert = alert });
        //}







        //private readonly AlertContext _context;
        //private readonly ILogger<AlertController> _logger;
        //private readonly IWebHostEnvironment _environment;
        ///// <summary>
        ///// OK ------7         Errrrroooooooooooooo@@@@@@@@
        ///// </summary>
        ///// <param name="video"></param>
        ///// <param name="location"></param>
        ///// <returns></returns>
        //[HttpPost("trigger")]
        //public async Task<IActionResult> TriggerAlert([FromForm] IFormFile video, [FromForm] string location)
        //{
        //    if (video == null || string.IsNullOrWhiteSpace(location))
        //    {
        //        return BadRequest("Video or location data is missing.");
        //    }

        //    var alert = new Alert
        //    {
        //        TimeStamp = DateTime.UtcNow,
        //        Location = location,
        //        VideoFilePath = string.Empty
        //    };

        //    if (video != null)
        //    {
        //        var videoPath = Path.Combine(_environment.WebRootPath, "uploads", $"{Guid.NewGuid()}.mp4");
        //        using (var stream = new FileStream(videoPath, FileMode.Create))
        //        {
        //            await video.CopyToAsync(stream);
        //            alert.VideoFilePath = videoPath;
        //        }
        //    }

        //    _context.Alerts.Add(alert);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { Message = "Alerta acionado com sucesso", Alert = alert });
        //}






        //private readonly AlertContext _context;
        //private readonly ILogger<AlertController> _logger;
        //private readonly IWebHostEnvironment _environment;

        ///// <summary>
        ///// alert 8 -------ok
        ///// </summary>
        ///// <param name="context"></param>
        ///// <param name="logger"></param>
        ///// <param name="environment"></param>
        ///// <exception cref="ArgumentNullException"></exception>
        //public AlertController(AlertContext context, ILogger<AlertController> logger, IWebHostEnvironment environment)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //    _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        //}

        //[HttpPost("trigger")]
        //public async Task<IActionResult> TriggerAlert([FromForm] IFormFile video, [FromForm] string location)
        //{
        //    _logger.LogInformation("TriggerAlert called with location: {Location}", location);

        //    if (video == null)
        //    {
        //        _logger.LogWarning("Video is missing.");
        //        return BadRequest("Video is required.");
        //    }

        //    if (string.IsNullOrWhiteSpace(location))
        //    {
        //        _logger.LogWarning("Location data is missing.");
        //        return BadRequest("Location data is required.");
        //    }

        //    var alert = new Alert
        //    {
        //        TimeStamp = DateTime.UtcNow,
        //        Location = location,
        //        VideoFilePath = string.Empty
        //    };

        //    if (video != null)
        //    {
        //        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        //        if (!Directory.Exists(uploadsFolder))
        //        {
        //            Directory.CreateDirectory(uploadsFolder);
        //        }

        //        var videoPath = Path.Combine(uploadsFolder, $"{Guid.NewGuid()}.mp4");
        //        using (var stream = new FileStream(videoPath, FileMode.Create))
        //        {
        //            await video.CopyToAsync(stream);
        //            alert.VideoFilePath = videoPath;
        //        }
        //    }

        //    _context.Alerts.Add(alert);
        //    await _context.SaveChangesAsync();

        //    _logger.LogInformation("Alert saved successfully with ID: {AlertId}", alert.Id);
        //    return Ok(new { Message = "Alerta acionado com sucesso", Alert = alert });
    }

}


