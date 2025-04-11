using JobDescriptionGenerator.Forms;

namespace JobDescriptionGenerator.Services;

public interface IGenerateDocService
{
    byte[] Generate(JobDescriptionForm form);
}
