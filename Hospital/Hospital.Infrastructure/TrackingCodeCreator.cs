using System.Text;

namespace Hospital.Infrastructure
{
    public class TrackingCodeCreator
    {
        public static string RandomTrackingCreator()
        {
            Random _random = new Random();
            var builder = new StringBuilder(8);

            char offset = 'A';
            const int lettersOffset = 26;
            char offset2 = 'a';
            char offset3 = '0';
            const int numbersOffset = 9;


            for (var i = 0; i < 12; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                var num = _random.Next(0, 3);
                if (num == 0)
                {
                    @char = (char)_random.Next(offset, offset + lettersOffset);
                }
                if (num == 1)
                {
                    @char = (char)_random.Next(offset2, offset2 + lettersOffset);
                }
                if (num == 2)
                {
                    @char = (char)_random.Next(offset3, offset3 + numbersOffset);
                }

                builder = builder.Append(@char);
            }

            return builder.ToString();
        }
    }
}