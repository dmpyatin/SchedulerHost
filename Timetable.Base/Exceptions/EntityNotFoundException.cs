using System;

namespace Timetable.Base.Exceptions
{
    [Serializable]
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException():base("Entity not founded"){}

        public EntityNotFoundException(string message): base(message)
        {            
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Message))
                return "Entity not found";

            return Message;
        }
    }
}
