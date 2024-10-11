using FluentValidation;
using Music.Market.Api.DTO;

namespace Music.Market.Api.Validators
{
    public class SaveArtistResourceValidator:AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistResourceValidator() 
        
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

        }


    }
}
