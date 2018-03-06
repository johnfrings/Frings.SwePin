using Frings.SePin.Data;
using Frings.SePin.Exceptions;

namespace Frings.SePin
{
    internal class Generator
    {
        public static Pin Generate(int year, int month, int day, int birthNumber)
        {
            if (Validator.Validate(year, month, day, birthNumber) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            var controlNumber = Math.ControlNumber.Get(year, month, day, birthNumber);

            return new Pin(year, month, day, birthNumber, controlNumber);
        }

        public static Pin Generate(int year, int month, int day, Sex sex)
        {
            if (Validator.Validate(year, month, day) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            var birthNumber = Math.Sex.GetRandomBirthNumber(sex);
            var controlNumber = Math.ControlNumber.Get(year, month, day, birthNumber);

            return new Pin(year, month, day, birthNumber, controlNumber);
        }

        public static Pin Generate(int year, int month, int day)
        {
            if (Validator.Validate(year, month, day) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            var birthNumber = Math.Sex.GetRandomBirthNumber(Math.Sex.GetRandom());
            var controlNumber = Math.ControlNumber.Get(year, month, day, birthNumber);

            return new Pin(year, month, day, birthNumber, controlNumber);
        }

        //// TODO: generate from age, sex, random day, random month+day, age + month, age + month + day
    }
}
