using System;
using Xunit;

namespace UnitTests.Domain
{
    public class IssueTest
    {

        [Fact]
        public void UpdatePoints_Should_Change_The_Issue_Points()
        {
            //Arrange
            IssueId id = new IssueId(new Guid());
            IssueDescription description = new IssueDescription("This is an issue");
            IssuePoints points = new IssuePoints(2);
            string assignedTo = "asignee";
            IssuePoints expectedPoints = new IssuePoints(4);

            //Act
            Issue sut = new Issue(id, description, points, assignedTo);
            sut.UpdatePoints(expectedPoints);
            IssuePoints currentPoints = sut.GetPoints();

            //Assert
            Assert.Equal(expectedPoints, currentPoints);


        }

    }
}
