using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RestFul.Models {

    /*______________MODEL______________*/
    public class CodingEvent {
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    }

    /*______________DTO (Data Transfer Object)______________*/

    /*  in relation to the POST handler in the Coding Events controller class...
     *  a input DTO is used to prevent an "over-posting [mass assignment]" attack
        https://cheatsheetseries.owasp.org/cheatsheets/Mass_Assignment_Cheat_Sheet.html
    */
    public class NewCodingEventDto {
    [NotNull]
    [Required]
    [StringLength(
      100,
      MinimumLength = 10,
      ErrorMessage = "Title must be between 10 and 100 characters"
    )]
    public string Title { get; set; }

    [NotNull]
    [Required]
    [StringLength(1000, ErrorMessage = "Description can't be more than 1000 characters")]
    public string Description { get; set; }

    [Required] [NotNull] public DateTime Date { get; set; }
  }


    // in relation to the PUT handler in the Coding Events Controller class...
    public class UpdateCodingEventDto : NewCodingEventDto
    {
        public long Id { get; set; }
    }
}
