namespace Application.UseCases.DeleteIssue;

public interface IOutputPort
{
    void Invalid();

    void Ok();

    void NotFound();

}
