using Infrastructure.DataAccess.Repositories.Fakes;
using Infrastructure.Repositories;

namespace UnitTests;

public class StandardFixture
{
    public IssueTrackerContextFake context;
    public IssueRepositoryFake IssueRepositoryFake;
    public SprintRepositoryFake SprintRepositoryFake;

    public StandardFixture()
    {
        context = new IssueTrackerContextFake();
        IssueRepositoryFake = new IssueRepositoryFake(context);
        SprintRepositoryFake = new SprintRepositoryFake(context);
    }
}
