using Domain;
using Domain.ValueObjects;
using System;
using Xunit;

namespace UnitTests.Domain;

public class IssueTest
{

    [Fact]
    public void UpdatePoints_Should_Change_The_Issue_Points()
    {
        //Arrange
        TrackerId id = new TrackerId(Guid.NewGuid());
        IssueDescription description = new IssueDescription("This is an issue");
        IssuePoints points = new IssuePoints(2);
        FirstName firstName = new FirstName("John");
        LastName lastName = new LastName("Doe");
        IUser assignee = new User(new TrackerId(Guid.NewGuid()), firstName, lastName);
        IssuePoints expectedPoints = new IssuePoints(4);

        //Act
        Issue sut = new Issue(id, description, points, assignee);
        sut.UpdatePoints(expectedPoints);
        IssuePoints currentPoints = sut.Points;

        //Assert
        Assert.Equal(expectedPoints, currentPoints);
    }

    [Fact]
    public void ChangeDescription_Should_Update_Description()
    {
        //Arrange
        TrackerId id = new TrackerId(new Guid());
        IssueDescription description = new IssueDescription("This is an issue");
        IssuePoints points = new IssuePoints(2);
        IssueDescription expectedDescription = new IssueDescription("This is an updated description");
        FirstName firstName = new FirstName("John");
        LastName lastName = new LastName("Doe");
        IUser assignee = new User(new TrackerId(Guid.NewGuid()), firstName, lastName);

        //Act
        Issue sut = new Issue(id, description, points, assignee);
        sut.UpdateDescription(expectedDescription);
        IssueDescription updatedDescription = sut.Description;

        //Assert
        Assert.Equal(expectedDescription, updatedDescription);
    }

    [Fact]
    public void Assign_Should_Update_Description()
    {
        //Arrange
        TrackerId id = new TrackerId(new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"));
        IssueDescription description = new IssueDescription("This is an issue");
        IssuePoints points = new IssuePoints(2);
        FirstName firstName = new FirstName("John");
        LastName lastName = new LastName("Doe");
        IUser assignee = new User(new TrackerId(Guid.NewGuid()), firstName, lastName);
        firstName = new FirstName("Bob");
        IUser expectedAssigne = new User(new TrackerId(Guid.NewGuid()), firstName, lastName);

        //Act
        Issue sut = new Issue(id, description, points, assignee);
        sut.Assign(expectedAssigne);
        IUser updatedAssignee = sut.AssignedTo;

        //Assert
        Assert.Equal(expectedAssigne.GetFullName(), updatedAssignee.GetFullName());
    }

    [Fact]
    public void UpdateProgress_Should_Update_IssueProgressStatus()
    {
        //Arrange
        TrackerId id = new TrackerId(new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"));
        IssueDescription description = new IssueDescription("This is an issue");
        IssuePoints points = new IssuePoints(2);
        FirstName firstName = new FirstName("John");
        LastName lastName = new LastName("Doe");
        IUser assignee = new User(new TrackerId(Guid.NewGuid()), firstName, lastName);
        IssueProgressStatus expectedStatus = IssueProgressStatus.InProgress;

        //Act
        Issue sut = new Issue(id, description, points, assignee);
        sut.UpdateProgress(expectedStatus);
        IssueProgressStatus updatedStatus = sut.Status;

        //Assert
        Assert.Equal(expectedStatus, updatedStatus);
    }


}
