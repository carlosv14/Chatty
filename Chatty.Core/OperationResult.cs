using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Core
{
    public class OperationResult
    {
        public OperationResult(IEnumerable<string> errors)
        {
            this.Errors = errors.ToList().AsReadOnly();
        }

        public OperationResult(bool success)
        {
            this.Succeeded = success;
        }

        public OperationResult()
        {
            this.Errors = new List<string>().AsReadOnly();
            this.Succeeded = false;
        }

        /// <summary>
        /// Gets list of errors for the operation
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }

        /// <summary>
        ///  Gets a value indicating whether true if the operation was successful
        /// </summary>
        ///
        public bool Succeeded { get; private set; }
    }
}
