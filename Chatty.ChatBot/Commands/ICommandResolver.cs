﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.ChatBot.Commands
{
    public interface ICommandResolver<TResult>
    {
        Task<TResult> ResolveAsync(string parameter);
    }
}
