namespace Frings.SwePin.Models
{
    internal class BirthNumber
    {
        private int _birthNumber;

        public BirthNumber(int birthNumber)
        {
            _birthNumber = birthNumber;
        }

        public static implicit operator int(BirthNumber birthNumber)
        {
            return birthNumber._birthNumber;
        }

        public static implicit operator BirthNumber(int birthNumber)
        {
            return new BirthNumber(birthNumber);
        }
    }
}
