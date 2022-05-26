using System.ComponentModel.DataAnnotations;

namespace WebApi.V1.Sprint.AddSprint;

public class AddSprintRequest
{
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

}
