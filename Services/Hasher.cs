using System.Linq;
using HashidsNet;
using WebDevHomework.Interfaces;

namespace WebDevHomework.Services
{
    public class Hasher : IHashDecoder, IHashEncoder
    {
        private readonly Hashids _hashId;
        
        public Hasher()
        {
            _hashId = new Hashids("some random salt", minHashLength : 8);
        }

        public string Encode(int id)
        {
            return _hashId.Encode(id);
        }

        public int Decode(string hashedUrl)
        {
            return _hashId.Decode(hashedUrl).First();
        }
    }
}