namespace FiscalFrontier.API.Models.DTO
{
    public class SecurityQuestionAnswerDto
    {
        public required string UserEmail { get; set; }
        public required string AnswerOne { get; set; }
        public required string AnswerTwo { get; set; }
    }
}
