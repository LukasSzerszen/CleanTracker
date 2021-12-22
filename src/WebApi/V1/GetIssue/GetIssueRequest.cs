using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public sealed class GetIssueRequest
{
    [Required]
    public Guid IssueId { get; set; }
}
