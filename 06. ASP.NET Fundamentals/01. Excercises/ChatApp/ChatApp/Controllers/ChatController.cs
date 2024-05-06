using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;

        private static List<KeyValuePair<string, string>> messages 
            = new List<KeyValuePair<string, string>>();

        public ChatController(ILogger<ChatController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count()<1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = messages
                .Select(x => new MessageViewModel()
                {
                    Sender = x.Key,
                    Message = x.Value
                }).ToList()
            };
            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message));

            return RedirectToAction("Show");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}