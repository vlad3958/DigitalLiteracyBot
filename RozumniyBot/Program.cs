

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot
{


    class TgBot
    {
        public static void Main()
        {
            var client = new TelegramBotClient("6983126867:AAE61KPbtgw5jIX5f8Sh2KwIzEad1PG_JdQ");

            client.StartReceiving(Update1, Error);
            Console.ReadLine();
        }

        public static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        public static int count = 0;
        public static List<string> list1 = new List<string>
        {
            "Робочий стіл", "Скринкаст", "Скористатися онлайн-банкінгом", "Explorer", "Адресу одержувача листа",
            "Однієї установи (його територіального об'єднання)", "Файл → Зберегти як → Тип файлу → PDF",
            "Місце для зберігання файлів документів", "Біт", "Спеціальною програмою",
            "MobileID, підпису на носії інформації", "пожежа в серверній кімнаті"
        };
            // public static List<string> list2 = new List<string>(12);
            public static Dictionary<string, List<string>> userResponses = new Dictionary<string, List<string>>();
        public static async Task Update1(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
           
               
                
                var message = update.Message;
                if (message != null)
                {
                    if (message.Type == MessageType.Text)
                    {
                        try
                        {

                        if (message.Text == "/start")
                        {
                            var replyKeyboardMarkup1 = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Почати тестування" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Привіт. Це бот-тестування для перевірки Вашого рівня цифрової грамотності. Тест буде складатися з 12 питань",
                                replyMarkup: replyKeyboardMarkup1);
                        }

                        if (message.Text == "Почати тестування")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Вікно завантаження", "Зображення монітора" },
                                new KeyboardButton[] { "Стіл з ярликами", "Робочий стіл" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 1/12\n\nЯку назву має основне вікно Windows, яке з'являється на екрані після повного завантаження операційної системи?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion2");
                            // await botClient.SendTextMessageAsync(message.Chat.Id, message.Text);
                         
                                }
                        else if(!message.Text.Contains("Next")&&!message.Text.Contains("start")&&!message.Text.Contains("End"))
                        {
                         
                            Console.WriteLine(count);

                            // Проверяем, есть ли уже ответы от данного пользователя
                            if (userResponses.ContainsKey(message.Chat.Id.ToString()))
                            {
                                // Пользователь уже отправил ответы, добавляем новый ответ в список
                                List<string> userResponseList = userResponses[message.Chat.Id.ToString()];
                                userResponseList.Add(message.Text);

                                Console.WriteLine($"Received response from user {message.Chat.Id.ToString()}: {message.Text}");
                                
                                Console.WriteLine( "Спасибо за ваш ответ!");
                            }
                            else
                            {
                                // Пользователь отправил первый вопрос или ответ
                                // Создаем новый список для данного пользователя
                                List<string> userResponseList = new List<string> { message.Text };
                                userResponses.Add(message.Chat.Id.ToString(), userResponseList);

                                // Отправляем подтверждение получения сообщения
                                Console.WriteLine( "Спасибо за ваш первый ответ!");
                               
                            }
                            var replyMarkup = new ReplyKeyboardRemove();
                            await botClient.SendTextMessageAsync(
                                message.Chat.Id,
                                "Keyboard closed.",
                                replyMarkup: replyMarkup
                            );
                            await botClient.SendTextMessageAsync(message.Chat.Id, $"Відповідь записана: {message.Text}");

                         // list2.Add(message.Text);
                           // foreach (var item in list2)
                           // {
                           //     Console.Write(" "+item);
                          //  }
                            // await botClient.SendTextMessageAsync(message.Chat.Id, $"Відповідь записана: {message.Text}");
                            // if (count+2>12)
                            // {
                            //     var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            //     {
                            //         new KeyboardButton[] { $"/EndTest" },
                            //     });
                            //     await botClient.SendTextMessageAsync(message.Chat.Id,
                            //         "=>",
                            //         replyMarkup: replyKeyboardMarkup);
                            // }
                            // else
                            // {
                            //
                            //     var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            //     {
                            //         new KeyboardButton[] { $"/NextQuestion{count + 2}" },
                            //     });
                            //     await botClient.SendTextMessageAsync(message.Chat.Id,
                            //         "=>",
                            //         replyMarkup: replyKeyboardMarkup);
                            // }

                            count++;
                            
                        }

                        if (message.Text == "/NextQuestion2")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Відеолекція", "Презентація" },
                                new KeyboardButton[] { "Слайд-шоу", "Скринкаст" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 2/12\n\nЯк називається коротке навчальне відео, яке містить запис того, що відбувається на екрані, і голосовий супровід автора?",
                                replyMarkup: replyKeyboardMarkup);
                          
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion3");
                        }

                        if (message.Text == "/NextQuestion3")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[]
                                    { "Звернутися до касира у відділенні банку", "Скористатися онлайн-банкінгом" },
                                new KeyboardButton[]
                                    { "Зателефонувати до комунальної установи", "Написати в чат спільноти" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 3/12\n\nВи бажаєте оплатити комунальні послуги онлайн. Яким способом це можна зробити?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion4");
                        }

                        if (message.Text == "/NextQuestion4")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "WINDOWS", "MS DOS" },
                                new KeyboardButton[] { "Explorer", "Linux" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 4/12\n\nЩо з переліченого НЕ є операційною системою?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion5");
                        }

                        if (message.Text == "/NextQuestion5")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Адресу відправника листа", "Адресу одержувача листа" },
                                new KeyboardButton[]
                                    { "Адресу сторінки поштової служби", "Коротке формулювання основної думки листа" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 5/12\n\nЩо під час складання електронного листа потрібно ввести в поле «Кому»?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion6");
                        }

                        if (message.Text == "/NextQuestion6")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "WWW", "Однієї кімнати" },
                                new KeyboardButton[]
                                    { "Однієї установи (його територіального об'єднання)", "Одного міста, району" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 6/12\n\nЛокальна комп'ютерна мережа — мережа, що складається з комп'ютерів, що пов'язуються в межах:",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion7");
                        }

                        if (message.Text == "/NextQuestion7")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Файл → Зберегти як → Тип файлу → PDF", "Файл → PDF" },
                                new KeyboardButton[] { "Параметри → Текст → PDF", "Сервіс → Параметри → PDF" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 7/12\n\nЯк зберегти документ Microsoft Word із розширенням типу *.pdf?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion8");
                        }

                        if (message.Text == "/NextQuestion8")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Місце для зберігання файлів документів", "Виконуваний файл" },
                                new KeyboardButton[] { "Текстовий документ", "Файл по-старому" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id, "Питання 8/12\n\nЩо таке папка?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion9");
                        }

                        if (message.Text == "/NextQuestion9")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Байт", "Кілобіт" },
                                new KeyboardButton[] { "Гбіт", "Біт" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 9/12\n\nМінімальною одиницю виміру кількості інформації заведено вважати:",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion10");
                        }

                        if (message.Text == "/NextQuestion10")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[] { "Перезавантажити систему", "Спеціальною програмою" },
                                new KeyboardButton[] { "Видалити вірус неможливо", "Видалити файли" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 10/12\n\nЯк можна видалити комп'ютерний вірус із диска?",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion11");
                        }

                        if (message.Text == "/NextQuestion11")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[]
                                {
                                    "MobileID, підпису на носії інформації",
                                    "підпису на носії інформації, текстового документа"
                                },
                                new KeyboardButton[] { "текстового документа, QR-коду", "QR-коду, MobileID" },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 11/12\n\nЕлектронний підпис може зберігатися у вигляді:",
                                replyMarkup: replyKeyboardMarkup);
                            await botClient.SendTextMessageAsync(message.Chat.Id, "/NextQuestion12");
                        }

                        if (message.Text == "/NextQuestion12")
                        {
                            var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                            {
                                new KeyboardButton[]
                                    { "пошкодження пристроїв інформаційної системи", "пожежа в серверній кімнаті" },
                                new KeyboardButton[]
                                {
                                    "знищення та спотворення даних, QR-коду",
                                    "несанкціоноване отримання особистих даних іншого користувача"
                                },
                            });
                            await botClient.SendTextMessageAsync(message.Chat.Id,
                                "Питання 12/12\n\nОберіть фактори, що не належать до загроз інформаційної безпеки:",
                                replyMarkup: replyKeyboardMarkup);
                           await botClient.SendTextMessageAsync(message.Chat.Id, "/EndTest");
                        }

                        if (message.Text == "/EndTest")
                        {
                            if (userResponses.ContainsKey(message.Chat.Id.ToString()))
                            {
                                // Пользователь уже отправил ответы, сравниваем с правильными ответами
                                List<string> userResponseList = userResponses[message.Chat.Id.ToString()];

                                var differences = userResponseList
                                    .Select((item, index) => new { Item = item, Index = index })
                                    .Where(x => x.Item !=
                                                list1[
                                                    x.Index]) // Предположим, что у вас есть список правильных ответов correctAnswers
                                    .ToList();

                                // Выводим различия и индексы для конкретного пользователя
                                await botClient.SendTextMessageAsync(message.Chat.Id,
                                    "Неправильні відповіді, та поради стосовно цих тем:\nhttps://osvita.diia.gov.ua/");

                                foreach (var diff in differences)
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id,
                                        $"Питання: {diff.Index + 1}\n Правильна відповідь: {list1[diff.Index]}\n Ваша відповідь => {diff.Item}");
                                }
                                foreach (var kvp in userResponses)
                                {
                                    Console.WriteLine($"Key: {kvp.Key}");

                                    foreach (var item in kvp.Value)
                                    {
                                        Console.WriteLine($"  - {item}");
                                    }

                                    Console.WriteLine(); // Add a newline for better readability
                                }
                                // Очищаем ответы пользователя
                                userResponses.Remove(message.Chat.Id.ToString());
                                count = 0;
                           
                            }
                        }

                        }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                       // throw;
                    }

                    }
                }

           
        }
    }
}