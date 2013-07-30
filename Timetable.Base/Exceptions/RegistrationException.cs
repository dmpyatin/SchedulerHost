using System;

namespace Timetable.Base.Exceptions
{
    [Serializable]
    public class RegistrationException: Exception
    {
        public RegistrationException(string message)
            : base(message)
        {            
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
