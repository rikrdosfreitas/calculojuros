using System;
using System.Collections.Generic;
using System.Linq;

namespace Juros.Common.Validation
{
    public class Guard
    {
        private readonly List<GuardValidationResult> _validationResults = new List<GuardValidationResult>();

        private Guard()
        {
        }

        public static void Validate(Action<Guard> action)
        {
            var guard = new Guard();
            action.Invoke(guard);

            if (guard._validationResults.Any())
            {
                throw new GuardValidationException(guard._validationResults.AsReadOnly());
            }
        }

        public Guard Min(int obj, int min, string name, string message)
        {
            if (obj < min)
            {
                _validationResults.Add(new GuardValidationResult(name, message));
            }

            return this;
        }

        public Guard Min(decimal obj, decimal min, string name, string message)
        {
            if (obj <= min)
            {
                _validationResults.Add(new GuardValidationResult(name, message));
            }

            return this;
        }
    }
}
