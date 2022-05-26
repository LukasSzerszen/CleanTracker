using System.Threading.Tasks;

namespace Application.UseCases.AddSprint;
public interface IAddSprintUseCase
{
    Task Execute(AddSprintInput input);
    IAddSprintOutputPort OutputPort { get; set; }
}
