using Domain;
using Domain.ValueObjects;
using System;
using Xunit;

namespace UnitTests.Domain
{
    public class UserTests
    {
        [Fact]
        public void CalculateKPI_returns_the_averageKPi()
        {
            //Arrange
            IssueCollection assignedIssues = new IssueCollection();
            IssueId id = new IssueId(new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"));
            IssueDescription description = new IssueDescription("This is an issue");
            IssuePoints points = new IssuePoints(2);
            string assignedTo = "asignee";
            Issue i1 = new Issue(id, description, points, assignedTo);
            assignedIssues.Add(i1.Id, i1);
            id = new IssueId(new Guid("9245fe4a-d402-451c-b9ed-9c1a04247483"));
            Issue i2 = new Issue(id, description, points, assignedTo);
            assignedIssues.Add(i2.Id, i2);

            //Act
            double expectedAverage = 2;
            double average = assignedIssues.CalculateKPI();

            //Assert
            Assert.Equal(expectedAverage, average);

        }
    }
}
