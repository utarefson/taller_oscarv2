using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LastPassProject.Helpers
{
    public class Searcher
    {
        public List<UserPassword> Segregate(string wordToSearch)
        {
            UserPasswordList userPasswordList = new UserPasswordList();
            var userPasswords = userPasswordList.SetData();
            var urlItems = userPasswords.Where(p => p.URL.Contains(wordToSearch)).ToList();
            var nameItems = userPasswords.Where(p => p.Name.Contains(wordToSearch)).ToList();
            var folderItems = userPasswords.Where(p => p.Folder.Contains(wordToSearch)).ToList();
            var usernameItems = userPasswords.Where(p => p.Username.Contains(wordToSearch)).ToList();
            var notesItems = userPasswords.Where(p => p.Notes.Contains(wordToSearch)).ToList();
            return urlItems.Union(nameItems).Union(folderItems).Union(usernameItems).Union(notesItems).ToList();

        }
    }
}
