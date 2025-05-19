using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame
{
    class TypeChart
    {
        public static Dictionary<string, Dictionary<string, float>> TypeEffectiveness = new()
        {
            { "fire", new Dictionary<string, float>
                {
                    {"grass", 2f}, {"steel", 2f}, {"fire", 0.5f}, {"rock", 0.5f}, {"water", 0.5f}
                }
            },
            { "grass", new Dictionary<string, float>
                {
                    {"rock", 2f}, {"water", 2f}, {"fire", 0.5f}, {"grass", 0.5f}, {"poison", 0.5f}, {"steel", 0.5f}
                }
            },
            { "poison", new Dictionary<string, float>
                {
                    {"grass", 2f}, {"rock", 0.5f}, {"steel", 0f}
                }
            },
        { "steel", new Dictionary<string, float>
         {
            {"rock", 2f}, {"electric", 0.5f}, {"fire", 0.5f}, {"water", 0.5f}, {"steel", 0.5f}
         }
        },
        { "water", new Dictionary<string, float>
         {
            {"fire", 2f}, {"rock", 2f}, {"grass", 0.5f}, {"water", 0.5f}
         }
        },
        { "electric", new Dictionary<string, float>
         {
            {"water", 2f}, {"electric", 0.5f}, {"grass", 0.5f}, {"rock", 0f}
         }
        },
        { "rock", new Dictionary<string, float>
         {
            {"fire", 2f}, {"rock", 0.5f}, {"steel", 0.5f}
         }
        }
    };
    }
}
