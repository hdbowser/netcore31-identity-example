using System;
using System.Collections.Generic;

namespace webapi1.Core {
    public class Result {
        public Result () {
            Errors = new List<string> ();
        }
        public bool Succedded {
            get {
                return Errors.Count == 0;
            }
        }
        public List<string> Errors { get; set; }
    }
}