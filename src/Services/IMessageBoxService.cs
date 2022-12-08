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

    public interface IMessageBoxService
    {
        /// <summary>
        /// Показать окно с сообщением.
        /// </summary>
        /// <param name="messageBoxText">Текст сообщения.</param>
        /// <param name="caption">Название окна.</param>
        /// <param name="button">Тип кнопок.</param>
        /// <param name="icon">Тип картинки.</param>
        /// <returns>Результат диалога с пользователем.</returns>
        bool Show(string messageBoxText, string caption,
            MessageButtons button, MessageIcon icon);
    }
}
