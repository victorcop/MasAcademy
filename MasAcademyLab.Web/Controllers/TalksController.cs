using MasAcademyLab.Service;
using MasAcademyLab.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace MasAcademyLab.Web.Controllers
{
    [Route("api/Trainings/{code}/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly ITalkService _talkService;
        private readonly LinkGenerator _linkGenerator;
        private readonly ITrainingService _trainingService;

        public TalksController(ITalkService talkService, LinkGenerator linkGenerator, ITrainingService trainingService)
        {
            _talkService = talkService;
            _linkGenerator = linkGenerator;
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string code, bool includeSpeakers = false)
        {
            var talks = await _talkService.GetTalksAsync(code, includeSpeakers);

            if (talks == null || !talks.Any())
            {
                return NoContent();
            }

            return Ok(talks);
        }

        [HttpGet("{talkId:int}")]
        public async Task<IActionResult> Get(string code, int talkId, bool includeSpeakers = false)
        {
            var talk = await _talkService.GetTalkAsync(code, talkId, includeSpeakers);

            if (talk == null)
            {
                return NotFound();
            }

            return Ok(talk);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string code, TalkCreationModel talkModel)
        {
            var talk = await _talkService.CreateTalkAsync(code, talkModel);

            var url = _linkGenerator.GetPathByAction(HttpContext,
                                                     "Get",
                                                     values: new { code, talkId = talk.TalkId });

            return Created(url, talk);
        }

        [HttpPut("{talkId:int}")]
        public async Task<IActionResult> Put(string code, int talkId, TalkUpdateModel talkModel)
        {
            if (!await _trainingService.Exists(code) || !await _talkService.Exists(code, talkId))
            {
                return NotFound();
            }

            var talk = await _talkService.UpdateTalkAsync(code, talkId, talkModel);

            return Ok(talk);
        }

        [HttpDelete("{talkId:int}")]
        public async Task<IActionResult> Delete(string code, int talkId)
        {
            if ( !await _trainingService.Exists(code) || !await _talkService.Exists(code, talkId))
            {
                return NotFound();
            }

            await _talkService.DeleteTalkAsync(code, talkId);

            return Ok();
        }
    }
}
