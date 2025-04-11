using Microsoft.AspNetCore.Mvc;
using JobDescriptionGenerator.Forms;
using JobDescriptionGenerator.Services;
using JobDescriptionGenerator.Constants;


namespace JobDescriptionGenerator.Controllers;

[Route("api/jobdoc")]
[ApiController]
public class JobDocController : ControllerBase
{
    private readonly IGenerateDocService _docService;

    public JobDocController(IGenerateDocService docService)
    {
        _docService = docService;
    }

    [HttpPost("generate")]
    public IActionResult GenerateDocument([FromBody] JobDescriptionForm form)
    {
        var fileBytes = _docService.GenerateDocument(form);
        var fileName = $"{form.JobTitleId}_Description.docx";

        //the long "application/.." string is the officially registered MIME type for .docx
        return File(fileBytes,
                    MimeTypes.Docx);
    }
}
