using System;

namespace Application.UseCases.AddSprint;
public record struct AddSprintInput(DateTime StartDate, DateTime EndDate);
