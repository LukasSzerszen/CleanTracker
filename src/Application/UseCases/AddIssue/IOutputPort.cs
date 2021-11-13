using Domain;
using Domain.ValueObjects;

namespace Application.UseCases.AddIssue
{
    public interface IOutputPort
    {
        void Invalid();

        void Ok(Issue issue);

        void NotFound();

    }
}
