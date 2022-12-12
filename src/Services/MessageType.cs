using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Пользовательский тип кнопок окна сообщения.
    /// </summary>
    public enum MessageButtons
    {
        Ok,
        OkCancel
    }

    /// <summary>
    /// Пользовательский тип картинок окна сообщения.
    /// </summary>
    public enum MessageIcon
    {
        Warning,
        Error,
        Info
    }
}
