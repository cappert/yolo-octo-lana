﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project30.Models;
using System.Web.Security;

namespace Project30.Controllers
{
   
    public class MessageController : Controller
    {
        private MessageContext db = new MessageContext();

        //
        // GET: /Message/
         [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        //
        // GET: /Message/Details/5
         [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        //
        // GET: /Message/Create
         [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Message/Create

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        //
        // GET: /Message/Edit/5
         [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        //
        // POST: /Message/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        //
        // GET: /Message/Delete/5
         [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        //
        // POST: /Message/Delete/5
         [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // allow non admins to add a message
        // get
        [Authorize]
         public ActionResult Add() {
  
            return View();
         }

        [HttpPost]
        [Authorize]
        public ActionResult Add(Message message)
        {
            message.CreationDate = DateTime.Now;

      
            UsersContext usersContext = new UsersContext();
            UserProfile user = usersContext.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == User.Identity.Name.ToLower());
   
            if (ModelState.IsValid && user != null)
            {
                message.UserProfile = user;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("MyMessages", new { newPost = "true" });
            }

            return View(message);
        }

        [Authorize]
        public ActionResult MyMessages(bool newPost = false) {

            ViewData["newPost"] = newPost;

            // @todo: update query to only return messages from the logged in users.
            List<Message> userMessages =  db.Messages.ToList();


            return View(userMessages);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}