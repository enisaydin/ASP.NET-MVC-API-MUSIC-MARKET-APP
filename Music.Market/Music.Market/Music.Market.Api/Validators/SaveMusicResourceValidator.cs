using FluentValidation;
using Music.Market.Api.DTO;

namespace Music.Market.Api.Validators
{
    public class SaveMusicResourceValidator:AbstractValidator<SaveMusicDTO>
    {
        public SaveMusicResourceValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ArtistId).NotEmpty().WithMessage("ArtistId must not be 0");
        }
    }
}
