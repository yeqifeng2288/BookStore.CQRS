using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.CQRS.Notifications;
using BookStore.CQRS.Services;
using BookStore.CQRS.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.CQRS.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookAppService _bookAppService;
        private readonly NotificationHandler _notifications;

        public BookController(IBookAppService bookAppService, INotificationHandler<Notification> notifications)
        {
            _bookAppService = bookAppService;
            _notifications = notifications as NotificationHandler;
        }
        public IActionResult Index()
        {
            var list = _bookAppService.GetList();
            return View(list);
        }

        public IActionResult AddBook()
        {
            return View(new AddBookViewModel());
        }

        [HttpPost]
        public IActionResult AddBook([FromForm] AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _bookAppService.AddBook(model);

            if (!_notifications.HasNotifications())
            {
                ViewBag.Successed = "添加书籍成功。";
            }

            return View(new AddBookViewModel());
        }
    }
}
