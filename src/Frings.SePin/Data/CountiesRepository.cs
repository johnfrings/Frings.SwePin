using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Frings.SePin.Models;

namespace Frings.SePin.Data
{
    internal class CountiesRepository : IEnumerable<County>
    {
        private static List<County> _counties;

        private readonly Random _random;

        public CountiesRepository()
        {
            _random = new Random((int)DateTime.Now.Ticks);

            _counties = new List<County>
            {
                new County("Stockholms län", new Range(1, 139)),
                new County("Uppsala län", new Range(140, 159)),
                new County("Södermanlands län", new Range(160, 189)),
                new County("Östergötlands län", new Range(190, 237)),
                new County("Jönköpings län", new Range(240, 269)),
                new County("Kronobergs län", new Range(270, 289)),
                new County("Kalmar län", new Range(290, 319)),
                new County("Gotlands län", new Range(320, 329)),
                new County("Blekinge län", new Range(330, 349)),
                new County("Kristianstads län", new Range(350, 389)),
                new County("Malmöhus län", new Range(390, 459)),
                new County("Hallands län", new Range(460, 479)),
                new County("Göteborgs och Bohus län", new Range(480, 549)),
                new County("Älvsborgs län", new Range(550, 589)),
                new County("Skaraborgs län", new Range(590, 619)),
                new County("Värmland län", new Range(620, 649)),
                new County("Örebro län", new Range(660, 689)),
                new County("Västmanlands län", new Range(690, 709)),
                new County("Kopparbergs län", new Range(710, 739)),
                new County("Gävleborgs län", new Range(750, 779)),
                new County("Västernorrlands län", new Range(780, 819)),
                new County("Jämtlands län", new Range(820, 849)),
                new County("Västerbottens län", new Range(850, 889)),
                new County("Norrbottens län", new Range(890, 929))
            };

            // Riksskatteverket 650-659
            // Riksskatteverket 740-749
            // Riksskatteverket 930-999
        }

        public County this[int index] => _counties[index];

        public County Get(int birthNumber)
        {
            return _counties.FirstOrDefault(c => c.Range.Contains(birthNumber)) ?? County.Empty;
        }

        public int GetRandomBirthNumber(County county, Sex sex = Sex.Unspecified)
        {
            int result;

            if (sex == Sex.Unspecified)
            {
                result = _random.Next(county.Range.From, county.Range.To);
            }
            else
            {
                var mid = county.Range.From + (county.Range.To - county.Range.From) / 2;

                result = _random.Next(county.Range.From, mid) * 2;

                if ((sex == Sex.Male && result % 2 == 0) ||
                    (sex == Sex.Female && result % 2 != 0))
                {
                    result--;
                }
            }

            return result;
        }

        public IEnumerator<County> GetEnumerator()
        {
            return _counties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
