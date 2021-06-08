using Domain.Interfaces;

namespace Application.UseCases.MoveIssue
{
    public interface IOutPutPort
    {

        void Invalid();


        void NotFound();


        void Ok(IIssue issue);
    }
}