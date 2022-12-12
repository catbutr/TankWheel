using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
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
