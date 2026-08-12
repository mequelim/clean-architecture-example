namespace AnemicDomainModel.Domain
{
    public sealed class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Client(int id, string name, string email)
        {
            ValidateInfos(id, name, email);

            Id = id;
            Name = name;
            Email = email;
        }

        //* Methods...
        public void UpdateInfos(int id, string name, string email)
        {
            ValidateInfos(id, name, email);

            Id = id;
            Name = name;
            Email = email;
        }

        private static void ValidateInfos(int id, string name, string email)
        {
            // Id validations...
            if(id <= 0) throw new ArgumentException("Id must be greater than or equal to 0!", nameof(id));

            // Name validations...
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or empty!", nameof(name));
            if(name.Length < 3) throw new ArgumentException("Name must be at least 3 characters long!", nameof(name));
            if(name.Length > 100) throw new ArgumentException("Name must be at most 100 characters long!", nameof(name));

            //* Email validations...
            if(string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be null or empty!", nameof(email));
            if(!email.Contains('@')) throw new ArgumentException("Email must contain '@'!", nameof(email));
            if(!email.Contains(".com")) throw new ArgumentException("Email must contain '.com'!", nameof(email));
        }
    }
}