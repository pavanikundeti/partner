using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Data;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly AppDataDbContext _apiDbContext;
        public EmailController(AppDataDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBench()
        {
            var bench = await _apiDbContext.EmailTemplates.ToListAsync();
            return Ok(bench);
        }




        [HttpPost]
        public async Task<IActionResult> AddEmail([FromBody] EmailTemplates benchRequest)
        {
            benchRequest.EmailTemplateID = Guid.NewGuid();
            await _apiDbContext.EmailTemplates.AddAsync(benchRequest);
            await _apiDbContext.SaveChangesAsync();



            return Ok(benchRequest);



        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmail([FromRoute] Guid id)
        {
            var bench =
            await _apiDbContext.EmailTemplates.FirstOrDefaultAsync(x => x.EmailTemplateID == id);
            if (bench == null)
            {
                return NotFound();



            }
            return Ok(bench);




        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBench([FromRoute] Guid id, EmailTemplates updateBenchRequest)
        {
            var bench = await _apiDbContext.EmailTemplates.FindAsync(id);
            if (bench == null)
            {
                return NotFound();
            }
            bench.TemplateName = updateBenchRequest.TemplateName;
            bench.TemplateCode = updateBenchRequest.TemplateCode;
            bench.MessageTemplate = updateBenchRequest.MessageTemplate;
            await _apiDbContext.SaveChangesAsync();
            return Ok(bench);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBench([FromRoute] Guid id)
        {
            var bench = await _apiDbContext.EmailTemplates.FindAsync(id);
            if (bench == null)
            {
                return NotFound();
            }
            _apiDbContext.EmailTemplates.Remove(bench);
            await _apiDbContext.SaveChangesAsync();
            return Ok(bench);
        }



    }
}
