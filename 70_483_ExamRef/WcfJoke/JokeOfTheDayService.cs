using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfJoke
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class JokeOfTheDayService : IJokeOfTheDayService
    {
        public string GetJoke(int jokeStrenght)
        {
            string result = "Invalis strenght";

            switch (jokeStrenght)
            {
                case 0:
                    result = "Knock, Knock";
                    break;
                case 1:
                    result = "Whats greek";
                    break;
                case 2:
                    result = "a horse";
                    break;
            }
            return result;
        }
    }
}
