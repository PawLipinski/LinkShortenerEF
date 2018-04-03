using WebDevHomework.Interfaces;

namespace WebDevHomework.Services
{
    public class Encoder : IHashEncoder
    {
        private readonly Hasher _hasher;

        public Encoder(Hasher hasher)
        {
            _hasher = hasher;
        }
        public string Encode(int id)
        {
            return _hasher.Encode(id);
        }
    }
}