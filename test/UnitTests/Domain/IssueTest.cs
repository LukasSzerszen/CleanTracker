using Domain;
using Domain.ValueObjects;
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
            IssuePoints currentPoints = sut.Points;

            //Assert
            Assert.Equal(expectedPoints, currentPoints);
        }

        [Fact]
        public void ChangeDescription_Should_Update_Description()
        {
            //Arrange
            IssueId id = new IssueId(new Guid());
            IssueDescription description = new IssueDescription("This is an issue");
            IssuePoints points = new IssuePoints(2);
            string assignedTo = "asignee";
            IssueDescription expectedDescription = new IssueDescription("This is an updated description");

            //Act
            Issue sut = new Issue(id, description, points, assignedTo);
            sut.UpdateDescription(expectedDescription);
            IssueDescription updatedDescription = sut.Description;

            //Assert
            Assert.Equal(expectedDescription, updatedDescription);
        }

        [Fact]
        public void Assign_Should_Update_Description()
        {
            //Arrange
            IssueId id = new IssueId(new Guid());
            IssueDescription description = new IssueDescription("This is an issue");
            IssuePoints points = new IssuePoints(2);
            string assignedTo = "assignee";
            string expectedAssigne = "I am another person";

            //Act
            Issue sut = new Issue(id, description, points, assignedTo);
            sut.Assign(expectedAssigne);
            string updatedAssignee = sut.AssignedTo;

            //Assert
            Assert.Equal(expectedAssigne, updatedAssignee);
        }

        [Fact]
        public void UpdateProgress_Should_Update_IssueProgressStatus()
        {
            //Arrange
            IssueId id = new IssueId(new Guid());
            IssueDescription description = new IssueDescription("This is an issue");
            IssuePoints points = new IssuePoints(2);
            string assignedTo = "assignee";
            IssueProgressStatus expectedStatus = IssueProgressStatus.InProgress;

            //Act
            Issue sut = new Issue(id, description, points, assignedTo);
            sut.UpdateProgress(expectedStatus);
            IssueProgressStatus updatedStatus = sut.Status;

            //Assert
            Assert.Equal(expectedStatus, updatedStatus);
        }


    }
}
